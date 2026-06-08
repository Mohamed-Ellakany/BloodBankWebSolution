namespace BloodBankWeb.Core.ViewModels
{
    public class PlateletsFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = Errors.RequiredField)]
        [Display(Name = "Blood Bank")]
        public int BloodBankId { get; set; }

        public IEnumerable<SelectListItem>? BloodBanks { get; set; }

        [Required(ErrorMessage = Errors.RequiredField)]
        [Display(Name = "Blood Type")]
        public int BloodTypeId { get; set; }

        public IEnumerable<SelectListItem>? BloodTypes { get; set; }

      


        [Range(1, 50, ErrorMessage = Errors.MinMaxRange)]
        public int Quantity { get; set; }

    }
}
