using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Common.ModelContracts.Reservation
{
    public record ReservationRequest
    (
        
         DateOnly DateOnly ,
         TimeOnly TimeOnly ,
         int BloodBankId

        );
    
}

