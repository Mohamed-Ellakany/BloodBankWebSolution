using BloodBank.Application.Common.ModelContracts.Auth;
using FluentValidation;

namespace BloodBank.Api.Contracts.Validations
{
    public class LoginRequestValidator :AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x=>x.Email).NotEmpty().EmailAddress();
            RuleFor(x=>x.Password).NotEmpty();
        }
    }
}
