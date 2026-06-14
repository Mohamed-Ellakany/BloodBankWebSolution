namespace BloodBankWeb.Core.ViewModels
{
    public class DonorViewModel
    {
        public int Id { get; set; }

        [MaxLength(200 ,ErrorMessage ="max lenght is 200")]
        public string Name { get; set; } = null!;

        [Range(18 , 45)]
        public int Age { get; set; }

        [Phone]
        public string PhoneNum { get; set; } = null!;

        public string NationalId { get; set; } = null!;

        public string City { get; set; } = string.Empty;

        public DateTime DonationDate { get; set; }


        public string BloodType { get; set; } = null!;

        public string Banks { get; set; } = null!;
    }
}
