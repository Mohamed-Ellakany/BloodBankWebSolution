using BloodBank.Application.Common.ModelContracts.Users;
using System.Security.Claims;


namespace BloodBank.Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;


        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;

        }

        public async Task<Result<UserProfileResponse>> GetProfileAsync(string userId)
        {
            var user = await _userManager.Users.Where(x => x.Id == userId).Include(x => x.BloodType)
                .ProjectToType<UserProfileResponse>()
                .SingleAsync();

            return Result.Success(user);

        }

        public async Task<Result> UpdateProfileAsync(string userId, UpdateProfileRequest request)
        {

            var user = await _userManager.FindByIdAsync(userId);

           

            user!.FullName = request.FullName;
            user.BloodTypeId = request.BloodTypeId;

            var result = await _userManager.UpdateAsync(user!);

            if (!result.Succeeded)
            {
                return Result.Failure(new Error("User.SomeThingWrong", "SomeThingWrong",StatusCodes.Status400BadRequest));
            }


            return Result.Success(user);

        }



        public async Task<Result> ChangePasswordAsync(string userId, ChangePasswordRequest request)
        {
            var user = await _userManager.FindByIdAsync(userId);

            var result = await _userManager.ChangePasswordAsync(user!, request.CurrentPassword, request.newPassword);

            if (result.Succeeded)
                return Result.Success();

            var error = result.Errors.First();

            return Result.Failure(new Error(error.Code , error.Description , StatusCodes.Status400BadRequest));

        }




    }
}
