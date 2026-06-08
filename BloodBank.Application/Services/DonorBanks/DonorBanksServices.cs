using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Services.DonorBanks
{
    public class DonorBanksServices : IDonorBanksServices
    {

        private readonly IUnitOfWork _unitOfWork;

        public DonorBanksServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IEnumerable<Donor?> GetAllInBank(int BankId)
        {
          return  _unitOfWork.DonorBanks.FindAll(predicate: bd => bd.BloodBankId == BankId, include: db => db.Include(x => x.Donor)!).Select(bd => bd.Donor);
        }








    }
}
