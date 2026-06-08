using BloodBank.Domain.Consts;

namespace BloodBankWeb.Core.ViewModels
{
    public class DonationRequest
    {
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }

        public int Age { get; set; }

        public string BloodBankId { get; set; }

        public DateOnly DateOnly { get; set; }

        public TimeOnly TimeOnly { get; set; }

        public int BloodTypeId { get; set; }

        [Range(1,2 , ErrorMessage ="must be 1 or 2 bags only ")]
        public int CountOfBags { get; set; }
    }
}
