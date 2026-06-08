using BloodBank.Application.Common.ModelContracts.Plateletses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Services.Plateletses
{
    public interface IPlateletsService
    {
        IEnumerable<Platelets> GetAll();

        public IEnumerable<Platelets> GetAllDeleted();

        IEnumerable<PlateletsesResponse> GetAllInType(int BloodTypeId);

        IEnumerable<PlateletsesResponse> GetAllInTypeInBank(int BloodTypeId, int BankId);

        Platelets? FindById(int id);

        public int Add(Platelets bag);

        int? Buy(int id);
    }
}
