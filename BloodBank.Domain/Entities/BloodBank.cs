
namespace BloodBank.Domain.Entities
{
    public class BloodBank
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;


        [Phone]
        public string PhoneNum { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;

        public int CityId { get; set; }

        public City City { get; set; } = null!;


        public ICollection<BloodBag> BloodBags { get; set; } = new HashSet<BloodBag>();

        public ICollection<Plasma> Plasmas { get; set; } = new HashSet<Plasma>();
        
        public ICollection<Platelets> Platelets { get; set; } = new HashSet<Platelets>();

        public ICollection<DonorBank> DonorBanks { get; set; } = new HashSet<DonorBank>();


        public ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();



    }
}
