using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Common.ModelContracts.Community
{
    public record PostResponse
    (
         int Id,string BloodTypeName , string Title , string HospitalName , DateTime DateOfPublish
    );
    
}


