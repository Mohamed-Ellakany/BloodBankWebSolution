using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Domain.Entities
{
    public class City
    {
        public  int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public ICollection<BloodBank> BloodBanks { get; set; } = new HashSet<BloodBank>();

        public ICollection<Donor> Donors { get; set; } = new HashSet<Donor>();

        public ICollection<ApplicationUser> Users { get; set; } = new HashSet<ApplicationUser>();

    }
}
