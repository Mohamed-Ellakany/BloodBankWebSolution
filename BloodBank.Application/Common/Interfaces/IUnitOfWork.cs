using BloodBank.Application.Common.Interfaces.Repositories;
using BloodBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<BloodBag> BloodBags { get;}

        IBaseRepository<Post> Posts { get;}

        IBaseRepository<Plasma> Plasmas { get;}
        
        IBaseRepository<City> Cites{ get;}

        IBaseRepository<Platelets> Platelets { get;}

        IBaseRepository<Reservation> Reservations { get; }

        IBaseRepository<Donor> Donors { get;}

        IBaseRepository<BloodType> BloodTypes { get;}

        IBaseRepository<DonorBank> DonorBanks { get;}

        IBaseRepository<BloodBank.Domain.Entities.BloodBank> BloodBanks { get;}

        int Complete();
    }
}
