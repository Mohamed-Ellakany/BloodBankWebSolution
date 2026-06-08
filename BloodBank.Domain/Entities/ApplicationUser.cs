namespace BloodBank.Domain.Entities
{
    [Index(nameof(Email) ,IsUnique =true)]
    [Index(nameof(UserName) ,IsUnique =true)]
    [Index(nameof(NationalId) ,IsUnique =true)]
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(150)]
        public string FullName { get; set; } = null!;

        public string NationalId { get; set; } = null!;

        public int? BloodTypeId { get; set; }

        public BloodType? BloodType { get; set; }

        public int? Age { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }


        public int BloodBankId { get; set; }
        public BloodBank BloodBank { get; set; }
    }
}
