using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Common.ModelContracts.Auth
{
    public record RegisterRequest
    (
        string Email,
        string FullName,
        string NationalId,
        string PhoneNumber,
        string Password,
        int BloodTypeId,
        int BloodBankId,
        int CityId
        );
}
