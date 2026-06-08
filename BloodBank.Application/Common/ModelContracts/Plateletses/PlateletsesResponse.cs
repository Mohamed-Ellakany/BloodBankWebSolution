using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Common.ModelContracts.Plateletses
{
    public record PlateletsesResponse
    (
       DateTime ExpirationDate, string BloodBankName, string BloodTypeName, string DonorName
    );
}
