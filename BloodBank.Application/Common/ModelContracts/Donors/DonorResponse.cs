using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Common.ModelContracts.Donors
{
    public record DonorResponse
    (
        string Name , string PhoneNum , DateTime DonationDate ,string? BloodType
        );
    
}


