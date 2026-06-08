using BloodBank.Domain.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Common.ModelContracts.Community
{
    public record PostRequest
    (
        string ContactPerson , string Title , string HospitalName , int BagsNeeded , string CityName , string Description , string MobileNumber, DateTime DateOfPublish , int BloodTypeId
        );
}
