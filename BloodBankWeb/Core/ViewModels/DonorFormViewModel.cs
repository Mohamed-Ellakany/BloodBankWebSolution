using UoN.ExpressiveAnnotations.NetCore.Attributes;

namespace BloodBankWeb.Core.ViewModels
{
    public class DonorFormViewModel
    {


        public int? Id { get; set; }

        [MaxLength(200) , RegularExpression(Regex.OnlyCharsAndSpaces, ErrorMessage =Errors.OnlyCharsAndSpaces) ]
        public string Name { get; set; } = null!;
         

        [Range(20,50 ,ErrorMessage =Errors.MinMaxRange) ]
        public int Age { get; set; }



        [Phone, Display(Name = "Phone number"), RegularExpression(Regex.PhoneNumberRegex, ErrorMessage = Errors.PhoneNumberError)]
        public string PhoneNum { get; set; } = null!;


       
        [Remote("CheckNationalId", null!, AdditionalFields = "Id", ErrorMessage = Errors.Dublicated), RegularExpression(Regex.NationalIdRegex, ErrorMessage = Errors.NationalIdRegexError)
           , MaxLength(50, ErrorMessage = Errors.MaxLength)]
        public string NationalId { get; set; } = null!;

        [AssertThat("DonationDate <= Today()" ,ErrorMessage =Errors.DateValidation)]
        public DateTime DonationDate { get; set; } = DateTime.Now;



        [Required(ErrorMessage = Errors.RequiredField)]
        [Display(Name = "Blood Bank")]
        public int BloodBankId { get; set; }

        public IEnumerable<SelectListItem>? BloodBanks { get; set; }


        [Required(ErrorMessage = Errors.RequiredField)]
        [Display(Name = "City")]
        public int CityId { get; set; }

        public IEnumerable<SelectListItem>? Cites { get; set; }



        [Required(ErrorMessage =Errors.RequiredField)]
        [Display(Name = "Blood Type")]
        public int BloodTypeId { get; set; }

        public IEnumerable<SelectListItem>? BloodTypes { get; set; }


    }
}
