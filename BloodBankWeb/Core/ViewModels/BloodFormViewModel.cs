
namespace BloodBankWeb.Core.ViewModels
{
    public class BloodFormViewModel
    {
        public int Id { get; set; }

        
        [Required(ErrorMessage =Errors.RequiredField)]
        [Display(Name ="Blood Type")]
        [Remote( "ValidateBloodType", null!, AdditionalFields = "DonorId", ErrorMessage = "The blood type does not match the donor's blood type.")]
        public int BloodTypeId { get; set; } 

        public IEnumerable<SelectListItem>? BloodTypes { get; set; }


        [Display(Name = "Donor Id")]
        [Required(ErrorMessage =Errors.RequiredField)]
        public int DonorId { get; set; }

        public IEnumerable<SelectListItem>? Donors { get; set; } = null!;


        [Range(1 , 2,ErrorMessage =Errors.MinMaxRange) ]
        public int Quantity { get; set; }

    }
}
