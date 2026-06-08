using BloodBank.Application.Common.ModelContracts.BloodBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Services.BloodBanks
{
    public interface IBloodBankServices
    {
        IEnumerable<BloodBank.Domain.Entities.BloodBank> GetAll();

        IEnumerable<BloodBank.Domain.Entities.BloodBank> GetAllOrdered();

         IEnumerable<BloodBankResponse>? GetAllForApp();

        IEnumerable<BloodBankResponse>? GetAllInCity(int cityId);
    }
}
