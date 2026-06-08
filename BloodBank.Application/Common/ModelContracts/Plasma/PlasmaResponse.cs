using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Common.ModelContracts.Plasma
{
    public record PlasmaResponse
    (
        DateTime ExpirationDate, string BloodBankName, string BloodTypeName, string DonorName
        );
    
}
