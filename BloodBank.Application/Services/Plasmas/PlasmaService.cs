using BloodBank.Application.Common.ModelContracts.BloodBag;
using BloodBank.Application.Common.ModelContracts.Plasma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Services.Plasmas
{
    public class PlasmaService :IPlasmaService
    {


        private readonly IUnitOfWork _unitOfWork;
        public PlasmaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Plasma> GetAll()
        {

            return _unitOfWork.Plasmas.FindAll(b => !b.IsDeleted && b.ExpirationDate > DateTime.Now,
                include: B => B.Include(x => x.BloodType)
                .Include(x => x.BloodBank));

        }

        public IEnumerable<Plasma> GetAllDeleted()
        {
            return _unitOfWork.Plasmas.FindAll(b => b.IsDeleted || b.ExpirationDate <= DateTime.Now,
                include: x => x.Include(B => B.BloodType)
                .Include(b => b.BloodBank));

        }

        public IEnumerable<PlasmaResponse> GetAllInType(int BloodTypeId)
        {
            var result = GetAll();

            var response = result.Where(b => b.BloodTypeId == BloodTypeId).Adapt<IEnumerable<PlasmaResponse>>();

            if (!response.Any()) return null;

            return response;
        }

        public IEnumerable<PlasmaResponse> GetAllInTypeInBank(int BloodTypeId, int BankId)
        {
            var result = GetAll();

            var response = result.Where(b => b.BloodTypeId == BloodTypeId && b.BloodBankId == BankId).Adapt<IEnumerable<PlasmaResponse>>();

            if (!response.Any()) return null;

            return response;
        }



        public  Plasma? FindById(int id)
        {
            return  _unitOfWork.Plasmas.Find(B => B.Id == id);
        }



        public int Add(Plasma bag)
        {
            _unitOfWork.Plasmas.Add(bag);

            return _unitOfWork.Complete();
        }

        public  int? Buy(int id)
        {
            var bag = FindById(id);

            if (bag is null)
                return null;

            bag.IsDeleted = true;

            return _unitOfWork.Complete();
        }



    }
}
