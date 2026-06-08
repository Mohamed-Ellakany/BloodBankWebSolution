namespace BloodBankWeb.Core.ViewModels
{
    public class BloodViewModel
    {
        public int Id { get; set; }

        public string BloodBank { get; set; } = null!;

        public string BloodType { get; set; } = null!;

        public string? Donor { get; set; }

        public int BloodBankId { get; set; }

        [Display(Name = "Expiration Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}" , ApplyFormatInEditMode = true)]
        public DateTime ExpirationDate { get; set; } = DateTime.Now.AddDays(15);

        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public int Quantity { get; set; }

    }
}
