using BloodBank.Application.Helper;
using BloodBank.Application.Services.BloodTypes;
using BloodBank.Application.Services.City;
using BloodBank.Domain.Consts;
using Hangfire;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace BloodBank.Application.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly ICityServices _cityServices;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AuthService> _logger;
        private readonly IJwtProvider _jwtProvider;
        private readonly IEmailSender _emailService;
        private readonly IBloodTypesServices _bloodTypesServices;
        private readonly IMemoryCache _memoryCache;
        private const int OTP_EXPIRATION_MINUTES = 10;

        public AuthService(
            ICityServices cityServices,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<AuthService> logger,
            IJwtProvider jwtProvider,
            IEmailSender emailService,
            IBloodTypesServices bloodTypesServices,
            IMemoryCache memoryCache)
        {
            _cityServices = cityServices;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _jwtProvider = jwtProvider;
            _emailService = emailService;
            _bloodTypesServices = bloodTypesServices;
            _memoryCache = memoryCache;
        }

        #region OTP Helpers
        private string GenerateOtp()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        private void StoreOtp(string userEmail, string otp, string otpType)
        {
            var cacheKey = $"{otpType}_{userEmail}";
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(OTP_EXPIRATION_MINUTES));

            _memoryCache.Set(cacheKey, otp, cacheEntryOptions);
        }

        private bool VerifyOtp(string userEmail, string otp, string otpType)
        {
            var cacheKey = $"{otpType}_{userEmail}";
            return _memoryCache.TryGetValue(cacheKey, out string? storedOtp) && storedOtp == otp;
        }

        private void RemoveOtp(string userEmail, string otpType)
        {
            var cacheKey = $"{otpType}_{userEmail}";
            _memoryCache.Remove(cacheKey);
        }
        #endregion

        #region Auth Methods
        public async Task<Result<AuthResponse>> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
                return Result.Failure<AuthResponse>(UserErrors.InvalidCredentials);

            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
            if (!result.Succeeded)
                return Result.Failure<AuthResponse>(result.IsNotAllowed ? UserErrors.EmailNotConfirmed : UserErrors.InvalidCredentials);

            var (token, expiresIn) = _jwtProvider.GenerateToken(user);
            return Result.Success(new AuthResponse(user.Id, user.Email!, user.FullName, token, expiresIn));
        }

        public async Task<Result> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default)
        {
            if (await _userManager.FindByEmailAsync(request.Email) is not null)
                return Result.Failure(UserErrors.DuplicatedEmail);

            if (await _userManager.Users.AnyAsync(u => u.NationalId == request.NationalId, cancellationToken))
                return Result.Failure(UserErrors.NationalIdIsExists);

            if ( _bloodTypesServices.GetById(request.BloodTypeId) is null )
                return Result.Failure(UserErrors.NotAllowedBloodType);

           if(_cityServices.GetById(request.CityId) is null)
                return Result.Failure(UserErrors.NoCityWithThisId);

            var user = new ApplicationUser
            {
                FullName = request.FullName,
                Email = request.Email,
                UserName = request.Email,
                NationalId = request.NationalId,
                PhoneNumber = request.PhoneNumber,
                BloodBankId= request.BloodBankId,
                BloodTypeId = request.BloodTypeId == 0 ? null : request.BloodTypeId,
                Age = ParseIdAndCalculateAge(request.NationalId).age
                   ,CityId =request.CityId

                };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                return Result.Failure(new Error(result.Errors.First().Code, result.Errors.First().Description , StatusCodes.Status400BadRequest));

            await _userManager.AddToRoleAsync(user, AppRoles.User);

            var otp = GenerateOtp();
            StoreOtp(user.Email!, otp, "EmailConfirmation");
            BackgroundJob.Enqueue(() => SendConfirmationEmail(user.Email!, user.FullName, otp));

            return Result.Success();
        }

        public async Task<Result> VerifyOtpAsync(VerifyOtpRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null )
                return Result.Failure(UserErrors.InvalidCode);

            if (!VerifyOtp(request.Email, request.Otp, request.OtpType))
                return Result.Failure(UserErrors.InvalidCode);

            return Result.Success();
        }

        public async Task<Result> ConfirmEmailAsync(ConfirmEmailRequest request)
        {
            var verifyResult = await VerifyOtpAsync(new VerifyOtpRequest(
                 request.Email, request.Code, "EmailConfirmation"));

            if (!verifyResult.IsSuccess)
                return verifyResult;

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
                return Result.Failure(UserErrors.InvalidCode);

            user.EmailConfirmed = true;
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                RemoveOtp(request.Email, "EmailConfirmation");
                return Result.Success();
            }

            return Result.Failure(new Error(result.Errors.First().Code, result.Errors.First().Description, StatusCodes.Status400BadRequest));
        }

        public async Task<Result> ResendConfirmEmailAsync(ResendConfirmationEmailRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null || user.EmailConfirmed)
                return Result.Failure(UserErrors.InvalidCredentials);

            var otp = GenerateOtp();
            StoreOtp(user.Email!, otp, "EmailConfirmation");
            BackgroundJob.Enqueue(() => SendConfirmationEmail(user.Email!, user.FullName, otp));

            return Result.Success();
        }

        public async Task<Result> SendResetPasswordCodeAsync(ForgetPasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
                return Result.Success(); 

            var otp = GenerateOtp();
            StoreOtp(user.Email!, otp, "PasswordReset");

            BackgroundJob.Enqueue(() => SendResetPasswordEmail(user.Email!, user.FullName, otp));

            return Result.Success();
        }

        public async Task<Result> ResetPasswordAsync(ResetPasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
                return Result.Failure(UserErrors.InvalidCode);

            var verifyResult = await VerifyOtpAsync(new VerifyOtpRequest(
                 request.Email, request.Code, "PasswordReset"));

            if (!verifyResult.IsSuccess)
                return verifyResult;

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, request.NewPassword);

            if (result.Succeeded)
            {
                RemoveOtp(user.Email!, "PasswordReset");
                return Result.Success();
            }

            return Result.Failure(new Error(result.Errors.First().Code, result.Errors.First().Description, StatusCodes.Status400BadRequest));
        }
        #endregion

        #region Email Methods
    

        public async Task SendConfirmationEmail( string email, string fullName, string otp)
        {
            var emailBody = EmailBodyBuilder.GenerateEmailBody("EmailConfirmation",
                new Dictionary<string, string>
                {
                    { "{{name}}", fullName },
                    { "{{otp}}", otp },
                    { "{{expiration}}", OTP_EXPIRATION_MINUTES.ToString() }
                }
            );

            await _emailService.SendEmailAsync(email, "✅ Blood Bank: Email Confirmation OTP", emailBody);
        }

        public async Task SendResetPasswordEmail( string email, string fullName, string otp)
        {
            var emailBody = EmailBodyBuilder.GenerateEmailBody("ForgetPassword",
                new Dictionary<string, string>
                {
                    { "{{name}}", fullName },
                    { "{{otp}}", otp },
                    { "{{expiration}}", OTP_EXPIRATION_MINUTES.ToString() }
                }
            );

            await _emailService.SendEmailAsync(email, "✅ Blood Bank: Password Reset OTP", emailBody);
        }
        #endregion

        public static (DateTime dob, int age) ParseIdAndCalculateAge(string id)
        {

            char centuryDigit = id[0];          
            string yearPart = id.Substring(1, 2); 
            string monthPart = id.Substring(3, 2); 
            string dayPart = id.Substring(5, 2);

            // Determine century
            int century = centuryDigit == '3' ? 2000 : 1900;
            int year = century + int.Parse(yearPart);
            int month = int.Parse(monthPart);
            int day = int.Parse(dayPart);

            // Create DateTime object
            DateTime dob;
            try
            {
                dob = new DateTime(year, month, day);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentException("Invalid date in ID");
            }

            // Calculate age
            int age = CalculateAge(dob, DateTime.Today);

            return (dob, age);
        }

        private static int CalculateAge(DateTime birthDate, DateTime referenceDate)
        {
            int age = referenceDate.Year - birthDate.Year;
            if (referenceDate.Month < birthDate.Month ||
                (referenceDate.Month == birthDate.Month && referenceDate.Day < birthDate.Day))
            {
                age--;
            }
            return age;
        }
    

}
}
