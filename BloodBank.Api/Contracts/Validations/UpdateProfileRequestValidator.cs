using BloodBank.Application.Common.ModelContracts.Users;
using BloodBank.Domain.Consts;

namespace BloodBank.Api.Contracts.Validations
{
    public class UpdateProfileRequestValidator : AbstractValidator<UpdateProfileRequest>
    {

        public UpdateProfileRequestValidator()
        {

            RuleFor(x => x.FullName).NotEmpty().Matches(Regex.OnlyCharsAndSpaces);



        }
    }
}