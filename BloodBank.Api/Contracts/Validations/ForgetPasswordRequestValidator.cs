using BloodBank.Application.Common.ModelContracts.Auth;

namespace BloodBank.Api.Contracts.Validations
{
    public class ForgetPasswordRequestValidator : AbstractValidator<ForgetPasswordRequest>
    {

        public ForgetPasswordRequestValidator()
        {

            RuleFor(x => x.Email).NotEmpty().EmailAddress();





        }
    }
}