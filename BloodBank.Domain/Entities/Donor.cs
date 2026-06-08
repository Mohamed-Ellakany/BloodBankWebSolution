

namespace BloodBank.Domain.Entities
{
    [Index(nameof(Name), nameof(NationalId))]
    [Index(nameof(NationalId))]
    public class Donor
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; } = null!;

        public int Age { get; set; }

        [Phone]
        public string PhoneNum { get; set; } = null!;

        public string NationalId { get; set; } = null!;

        public DateTime DonationDate { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

        public int BloodTypeId { get; set; }

        public BloodType BloodType { get; set; } = null!;

        public ICollection<BloodBag> BloodBags { get; set; } = new HashSet<BloodBag>();
        
        public ICollection<DonorBank> DonorBanks { get; set; } = new HashSet<DonorBank>();


    }
}
