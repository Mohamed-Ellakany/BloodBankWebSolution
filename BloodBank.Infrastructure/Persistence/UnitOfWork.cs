using BloodBank.Application.Common.Interfaces.Repositories;
using BloodBank.Domain.Entities;
using BloodBank.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IBaseRepository<BloodBag> BloodBags =>  new BaseRepository<BloodBag>(_context);

        public IBaseRepository<Post> Posts =>  new BaseRepository<Post>(_context);

        public IBaseRepository<Plasma> Plasmas => new BaseRepository<Plasma>(_context);

        public IBaseRepository<City> Cites => new BaseRepository<City>(_context);

        public IBaseRepository<Platelets> Platelets => new BaseRepository<Platelets>(_context);

        public IBaseRepository<Donor> Donors => new BaseRepository<Donor>(_context);

        public IBaseRepository<Reservation> Reservations => new BaseRepository<Reservation>(_context);

        public IBaseRepository<BloodType> BloodTypes => new BaseRepository<BloodType>(_context);

        public IBaseRepository<DonorBank> DonorBanks => new BaseRepository<DonorBank>(_context);

        public IBaseRepository<BloodBank.Domain.Entities.BloodBank> BloodBanks => new BaseRepository<BloodBank.Domain.Entities.BloodBank>(_context);


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
           _context.Dispose();
        }
    }
}
