using BloodBank.Application.Common.ModelContracts.Types;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Services.BloodTypes
{
    public class BloodTypesServices : IBloodTypesServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public BloodTypesServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public  IEnumerable<BloodTypesResponse> GetAll()
        {

            var all =  _unitOfWork.BloodTypes.GetAll();

            var allmapped = all.Adapt<IEnumerable<BloodTypesResponse>>();

            return allmapped;

        }
        
        public IEnumerable<BloodType> GetAllOrdered()
        {
            return _unitOfWork.BloodTypes.GetAllOrderd(orderBy: BT => BT.Name);

        }
        public  BloodTypesResponse? GetById(int id) 
        {
            var re = _unitOfWork.BloodTypes.GetById(id).Adapt<BloodTypesResponse>();

          return re; 
        
        }

    }
}
