using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Common.ModelContracts.Community
{
    public record PostDetailsResponse
    (
        int Id, string ContactPerson, string Title, string HospitalName, int BagsNeeded,string MobileNumber, string CityName, string Description, DateTime DateOfPublish, string BloodTypeName
        );
    
}

