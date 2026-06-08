using UoN.ExpressiveAnnotations.NetCore.Attributes;

namespace BloodBankWeb.Core.ViewModels
{
    public class UserFormViewModel
    {
        public string? Id { get; set; }

        [RegularExpression(Regex.OnlyCharsAndSpaces, ErrorMessage = Errors.OnlyCharsAndSpaces), MaxLength(100, ErrorMessage = Errors.MaxLength), Display(Name = "Full Name")]
        public string FullName { get; set; } = null!;


        [RegularExpression(Regex.UserNameRegex, ErrorMessage = Errors.UserNameRegexError), MaxLength(20, ErrorMessage = Errors.MaxLength), Display(Name = "Username")]
        public string UserName { get; set; } = null!;


        [RegularExpression(Regex.Emails, ErrorMessage = Errors.EmailsRegexError), Remote("AllowEmails", null!, AdditionalFields = "Id", ErrorMessage = Errors.Dublicated), MaxLength(200, ErrorMessage = Errors.MaxLength), EmailAddress]
        public string Email { get; set; } = null!;


        [Phone, Display(Name = "Phone number"), RegularExpression(Regex.PhoneNumberRegex, ErrorMessage = Errors.PhoneNumberError)]
        public string PhoneNumber { get; set; } = null!;


        [Remote("CheckNationalId", null!, AdditionalFields = "Id", ErrorMessage = Errors.Dublicated), RegularExpression(Regex.NationalIdRegex, ErrorMessage = Errors.NationalIdRegexError)
            , MaxLength(50, ErrorMessage = Errors.MaxLength)]
        public string NationalId { get; set; } = null!;


        [Required(ErrorMessage = Errors.RequiredField)]
        [Display(Name = "Blood Type")]
        public int? SelectedBloodType { get; set; }

        public IEnumerable<SelectListItem>? BloodTypes { get; set; }


        [Display(Name = "Bank")]
        public int BloodBankId { get; set; }

        public IEnumerable<SelectListItem>? Banks { get; set; }
        

        [Required(ErrorMessage = Errors.RequiredField)]
        [Display(Name = "City")]
        public int CityId { get; set; }

        public IEnumerable<SelectListItem>? Cites { get; set; }



        [Display(Name = "Roles")]
        public IList<string> SelectedRoles { get; set; } = new List<string>();

        public IEnumerable<SelectListItem>? Roles { get; set; }

      


        [RequiredIf("Id == null", ErrorMessage = Errors.RequiredField)
            , RegularExpression(Regex.Passwords, ErrorMessage = Errors.weakPassword)
            , DataType(DataType.Password)
            , StringLength(100, ErrorMessage = Errors.MinMaxLength, MinimumLength = 6)]
        public string? Password { get; set; } = null!;



        [RequiredIf("Id == null", ErrorMessage = Errors.RequiredField)
            , RegularExpression(Regex.Passwords, ErrorMessage = Errors.weakPassword)
            , DataType(DataType.Password),
            Display(Name = "Confirm password"),
            Compare("Password", ErrorMessage = Errors.ConfirmationPassword)]
        public string? ConfirmPassword { get; set; } = null!;

    }
}
