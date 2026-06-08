using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Common.ModelContracts.Auth;

    public record LoginRequest(
        string Email,
        string Password);
    

