using BloodBank.Application.Common.ModelContracts.AI;
using BloodBank.Application.Common.ModelContracts.Community;
using BloodBank.Domain.Consts;

namespace BloodBank.Api.Contracts.Validations
{

    public class RecommendedRequestValidator : AbstractValidator<RecommendedRequest>
    {

        public RecommendedRequestValidator()
        {
            RuleFor(x => x.blood_type).NotEmpty().WithMessage(Errors.RequiredField);

            RuleFor(x => x.Governorate).NotEmpty().WithMessage(Errors.RequiredField);

            RuleFor(x => x.Quantity).NotEmpty().WithMessage(Errors.RequiredField);
        }
    }
}
