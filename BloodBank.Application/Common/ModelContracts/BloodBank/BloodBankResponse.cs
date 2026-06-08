using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Common.ModelContracts.BloodBank
{
    public record BloodBankResponse
        (
        int Id , string Name , string Address 
        );
   
}
