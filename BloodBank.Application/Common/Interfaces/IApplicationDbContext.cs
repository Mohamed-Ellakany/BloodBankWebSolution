using BloodBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {

        public DbSet<BloodBank.Domain.Entities.BloodBank> BloodBanks { get; set; }


        public DbSet<BloodBag> BloodBags { get; set; }


        public DbSet<Plasma> Plasmas { get; set; }

        public DbSet<DonorBank> DonorBanks { get; set; }


        public DbSet<Platelets> Platelets { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Donor> Donors { get; set; }

        public DbSet<BloodType> BloodTypes { get; set; }

        int SaveChanges();

    }
}
