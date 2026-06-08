using BloodBank.Application.Common.ModelContracts.Auth;

namespace BloodBank.Api.Contracts.Validations
{
    public class ResendConfirmationEmailRequestValidator : AbstractValidator<ResendConfirmationEmailRequest>
    {

        public ResendConfirmationEmailRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }

    }
}
