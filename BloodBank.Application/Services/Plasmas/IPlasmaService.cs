using BloodBank.Application.Common.ModelContracts.Plasma;
using BloodBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Services.Plasmas
{
    public interface IPlasmaService
    {
        IEnumerable<Plasma> GetAll();

        IEnumerable<Plasma> GetAllDeleted();

        IEnumerable<PlasmaResponse>? GetAllInType(int BloodTypeId);

        IEnumerable<PlasmaResponse>? GetAllInTypeInBank(int BloodTypeId, int BankId);

        Plasma? FindById(int id);

        int Add(Plasma bag);

        int? Buy(int id);
    }
}
