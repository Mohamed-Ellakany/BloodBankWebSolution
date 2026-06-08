using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BloodBank.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> , IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DonorBank>().HasKey(db => new { db.DonorId , db.BloodBankId});

            var cascadeFKs = builder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => fk.DeleteBehavior == DeleteBehavior.Cascade && !fk.IsOwnership);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(builder);
        }


        public DbSet<BloodBank.Domain.Entities.BloodBank> BloodBanks { get; set; }

        public DbSet<BloodBag> BloodBags { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Plasma> Plasmas { get; set; }
        
        public DbSet<DonorBank> DonorBanks { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Platelets> Platelets { get; set; }

        public DbSet<Donor> Donors { get; set; }

        public DbSet<BloodType> BloodTypes { get; set; }


    }
}
