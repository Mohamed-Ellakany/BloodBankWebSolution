using BloodBank.Application.Common.ModelContracts.City;
using BloodBank.Application.Common.ModelContracts.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Services.City
{
    public class CityServices(IUnitOfWork unitOfWork) : ICityServices
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public IEnumerable<CityResponse> GetAll()
        {
            return _unitOfWork.Cites.GetAll().Adapt<IEnumerable<CityResponse>>();
        }

        public CityResponse? GetById(int id)
        {
            var re = _unitOfWork.Cites.GetById(id).Adapt<CityResponse>();

            return re;

        }
    }
}
