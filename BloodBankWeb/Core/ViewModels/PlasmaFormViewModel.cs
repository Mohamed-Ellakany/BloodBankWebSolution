
namespace BloodBankWeb.Core.ViewModels
{
    public class PlasmaFormViewModel
    {
        public int Id { get; set; }

      

        [Required(ErrorMessage = Errors.RequiredField)]
        [Display(Name = "Blood Type")]
        public int BloodTypeId { get; set; }

        public IEnumerable<SelectListItem>? BloodTypes { get; set; }


        [Range(1, 50, ErrorMessage =Errors.MinMaxRange)]
        public int Quantity { get; set; }
    }
}
