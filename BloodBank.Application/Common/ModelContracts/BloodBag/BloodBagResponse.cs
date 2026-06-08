using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Common.ModelContracts.BloodBag
{
    public record BloodBagResponse
    (
         DateTime ExpirationDate , string BloodBankName ,string BloodTypeName , string DonorName , int Quantity , bool IsDeleted

        );
    
}
