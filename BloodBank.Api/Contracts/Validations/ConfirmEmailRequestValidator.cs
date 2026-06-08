using BloodBank.Application.Common.ModelContracts.Auth;

namespace BloodBank.Api.Contracts.Validations
{
    public class ConfirmEmailRequestValidator : AbstractValidator<ConfirmEmailRequest>
    {
        public ConfirmEmailRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
           // RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
