using BloodBank.Application.Common.ModelContracts.Auth;
using BloodBank.Domain.Consts;

namespace BloodBank.Api.Contracts.Validations
{
    public class ResetPasswordRequestValidator : AbstractValidator<ResetPasswordRequest>
    {

        public ResetPasswordRequestValidator()
        {

            RuleFor(x => x.Email).NotEmpty().EmailAddress();


            RuleFor(x => x.Code).NotEmpty();


            RuleFor(x => x.NewPassword).NotEmpty().Matches(Regex.Passwords).WithMessage(Errors.weakPassword + ", password should be have 8 digits and should be contains lowercase , NonAlphanumeric and uppercase chars");



        }

        }
    }
