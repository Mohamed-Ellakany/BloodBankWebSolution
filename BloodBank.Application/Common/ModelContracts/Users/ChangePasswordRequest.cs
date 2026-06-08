using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Common.ModelContracts.Users
{
    public  record ChangePasswordRequest
    (
    string CurrentPassword ,
    string newPassword 
    );
}
