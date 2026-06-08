using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Services.DonorBanks
{
    public interface IDonorBanksServices
    {
       IEnumerable<Donor?> GetAllInBank(int BankId);
            
    }
}
