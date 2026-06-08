using BloodBank.Application.Common.ModelContracts.Users;
using BloodBank.Domain.Consts;

namespace BloodBank.Api.Contracts.Validations
{
    public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
    {

        public ChangePasswordRequestValidator()
        {

            RuleFor(x => x.CurrentPassword).NotEmpty();

            RuleFor(x => x.newPassword).NotEmpty()
                .Matches(Regex.Passwords)
                .WithMessage(Errors.weakPassword + ",password should be have 8 digits and should be contains lowercase , NonAlphanumeric and uppercase chars")
                .NotEqual(x=>x.CurrentPassword)
                .WithMessage("new password cannot be same as the current password");



        }
    }
}