

namespace BloodBank.Application.Services.AuthServices
{
    public interface IAuthService
    {
        // Authentication
        Task<Result<AuthResponse>> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default);

        // Registration
        Task<Result> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default);

        // OTP Verification
        Task<Result> VerifyOtpAsync(VerifyOtpRequest request);

        // Email Confirmation
        Task<Result> ConfirmEmailAsync(ConfirmEmailRequest request);
        Task<Result> ResendConfirmEmailAsync(ResendConfirmationEmailRequest request);

        // Password Recovery
        Task<Result> SendResetPasswordCodeAsync(ForgetPasswordRequest request);
        Task<Result> ResetPasswordAsync(ResetPasswordRequest request);

        // Email Sending (these are implemented in the service but typically wouldn't be part of the interface)
        Task SendConfirmationEmail( string email, string fullName, string otp);
        Task SendResetPasswordEmail( string email, string fullName, string otp);

    }
}