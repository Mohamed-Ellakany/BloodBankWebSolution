using BloodBank.Application.Common.ModelContracts.Donors;
using BloodBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Services.Donors
{
    public interface IDonorsServices
    {

         IEnumerable<Donor> GetAll();

        public IEnumerable<DonorResponse> GetAllForApp();

        bool CheckNational(int? id, string nationalId);

        IEnumerable<Donor> GetAllInBank(int BankId);

        Donor? GetById(int id);

         int Add(Donor donor);

         void UpdateDonationDate(Donor donor);
    }
}
