using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Common.ModelContracts.Users
{
    public record UserProfileResponse
    (
        string FullName,
        string Email,
        string NationalId,
        string? BloodType
        );
}
