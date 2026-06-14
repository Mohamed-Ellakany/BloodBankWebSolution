using BloodBank.Application.Common.ModelContracts.BloodBag;
using BloodBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Services.Blood
{
    public interface IBloodSevrice
    {
        IEnumerable<BloodBag> GetAll();

         IEnumerable<BloodBag> GetAllDeleted();

        IEnumerable<BloodBagResponse>? GetAllInType(int BloodTypeId);

        IEnumerable<BloodBagResponse>? GetAllInTypeInBank(int BloodTypeId, int BankId);

       BloodBag? FindById(int id);

        public int Add(BloodBag bag);


        int? Buy(int id);
    }
}
