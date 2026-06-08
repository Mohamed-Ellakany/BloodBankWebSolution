namespace BloodBankWeb.Core.ViewModels
{
    public class DonationFormViewModel
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = Errors.RequiredField)]
        //[Display(Name = "Blood Bank")]
        //public int BloodBankId { get; set; }

        //public IEnumerable<SelectListItem>? BloodBanks { get; set; }

        [Required(ErrorMessage = Errors.RequiredField)]
        [Display(Name = "Blood Type")]
        [Remote("ValidateBloodType", null!, AdditionalFields = "DonorId", ErrorMessage = "The blood type does not match the donor's blood type.")]
        public int BloodTypeId { get; set; }

        public IEnumerable<SelectListItem>? BloodTypes { get; set; }


        [Range(1, 2, ErrorMessage = Errors.MinMaxRange)]
        public int Quantity { get; set; }


        public string ApplicationUserId { get; set; }

  


    }
}
