using BloodBank.Application.Common.ModelContracts.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Services.City
{
    public interface ICityServices
    {
        IEnumerable<CityResponse> GetAll();
        CityResponse? GetById(int id);
    }
}
