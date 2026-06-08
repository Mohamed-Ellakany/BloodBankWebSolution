using BloodBank.Application.Common.ModelContracts.Community;
using BloodBank.Application.Common.ModelContracts.Users;
using BloodBank.Domain.Consts;
using System.ComponentModel.DataAnnotations;

namespace BloodBank.Api.Contracts.Validations
{
    public class PostRequestValidation : AbstractValidator<PostRequest>
    {

        public PostRequestValidation()
        {

            RuleFor(x => x.HospitalName).NotEmpty().WithMessage(Errors.RequiredField).MaximumLength(100).WithMessage(Errors.MaxLength);


            RuleFor(x => x.ContactPerson).NotEmpty().WithMessage(Errors.RequiredField).Matches(Regex.OnlyCharsAndSpaces).WithMessage(Errors.OnlyCharsAndSpaces);


            RuleFor(x => x.Title).NotEmpty().WithMessage(Errors.RequiredField).MaximumLength(100).WithMessage(Errors.MaxLength);


            RuleFor(x => x.MobileNumber).NotEmpty().WithMessage(Errors.RequiredField).Matches(Regex.PhoneNumberRegex).WithMessage(Errors.PhoneNumberError);


            RuleFor(x => x.BagsNeeded).NotEmpty().WithMessage(Errors.RequiredField).GreaterThan(0);


            RuleFor(x => x.CityName).NotEmpty().WithMessage(Errors.RequiredField).MaximumLength(30).WithMessage(Errors.MaxLength);


            RuleFor(x => x.Description).NotEmpty().WithMessage(Errors.RequiredField).MaximumLength(200).WithMessage(Errors.MaxLength);


            RuleFor(x => x.DateOfPublish).NotEmpty().WithMessage(Errors.RequiredField);


            RuleFor(x => x.BloodTypeId).NotEmpty().WithMessage(Errors.RequiredField).GreaterThan(0);



        }
    }
}
