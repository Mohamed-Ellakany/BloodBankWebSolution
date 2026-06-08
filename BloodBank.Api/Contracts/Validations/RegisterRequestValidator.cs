using BloodBank.Application.Common.ModelContracts.Auth;
using BloodBank.Domain.Consts;
using FluentValidation;

namespace BloodBank.Api.Contracts.Validations
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
      
        public RegisterRequestValidator()
        {

            RuleFor(x => x.Email).NotEmpty().EmailAddress();


            RuleFor(x => x.Password).NotEmpty().Matches(Regex.Passwords).WithMessage(Errors.weakPassword + ", password should be have 8 digits and should be contains lowercase , NonAlphanumeric and uppercase chars");


            RuleFor(x => x.FullName).NotEmpty().Matches(Regex.OnlyCharsAndSpaces)
                ;
            RuleFor(x => x.PhoneNumber).NotEmpty().Matches(Regex.PhoneNumberRegex);

            RuleFor(x => x.CityId).NotEmpty();

          
            
            RuleFor(x => x.NationalId)
                .NotEmpty().Matches(Regex.NationalIdRegex)
                .WithMessage("it's not national Id");


        }
    }
}
