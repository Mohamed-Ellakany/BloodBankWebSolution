using BloodBank.Application.Common.Interfaces;
using BloodBank.Application.Common.ModelContracts.BloodBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Services.BloodBanks
{
    public class BloodBankServices : IBloodBankServices
    {

        private readonly IUnitOfWork _unitOfWork;

        public BloodBankServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IEnumerable<BloodBank.Domain.Entities.BloodBank> GetAll()
        {
            return _unitOfWork.BloodBanks.GetAll();
        }

        public IEnumerable<BloodBank.Domain.Entities.BloodBank> GetAllOrdered()
        {
            return _unitOfWork.BloodBanks.GetAllOrderd(orderBy: BT => BT.Name);
        }


        public IEnumerable<BloodBankResponse>? GetAllForApp()
        {
            var response = _unitOfWork.BloodBanks.GetAll().Adapt<IEnumerable<BloodBankResponse>>();

            if (response.Any())
            {
                return response;
            }
            else 
            {
                return null;
            }

        }


        public IEnumerable<BloodBankResponse>? GetAllInCity(int cityId)
        {
           var city  =  _unitOfWork.Cites.GetById(cityId);
            if (city is null)
                return null;

            return _unitOfWork.BloodBanks.FindAll(b => b.CityId == cityId).Adapt<IEnumerable<BloodBankResponse>>();
        }


    }
}
