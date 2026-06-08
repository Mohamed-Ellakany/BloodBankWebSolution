
namespace BloodBank.Domain.Entities
{
    public class BloodType
    {
        public int Id { get; set; }

        [MaxLength(4)]
        public string Name { get; set; } = null!;


        public ICollection<BloodBag>  BloodBags { get; set; } = new HashSet<BloodBag>();

        public ICollection<Plasma> Plasmas { get; set; } = new HashSet<Plasma>();

        public ICollection<Platelets> Platelets { get; set; } = new HashSet<Platelets>();

        public ICollection<Donor> Donors { get; set; } = new HashSet<Donor>();

        public ICollection<ApplicationUser> ApplicationUser { get; set; } = new HashSet<ApplicationUser>();

        public ICollection<Post> posts { get; set; } = new HashSet<Post>();

    }
}
