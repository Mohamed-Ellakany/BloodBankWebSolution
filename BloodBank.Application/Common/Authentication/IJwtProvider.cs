using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Common.Authentication
{
    public interface IJwtProvider
    {
        (string token , int expiresIn) GenerateToken(ApplicationUser user);

    }
}
