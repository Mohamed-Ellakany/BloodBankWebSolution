using BloodBank.Application.Common.ModelContracts.Plasma;
using BloodBank.Application.Common.ModelContracts.Plateletses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Services.Plateletses
{
    public class PlateletsService :IPlateletsService
    {

        private readonly IUnitOfWork _unitOfWork;
        public PlateletsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Platelets> GetAll()
        {

            return _unitOfWork.Platelets.FindAll(b => !b.IsDeleted && b.ExpirationDate > DateTime.Now,
                include: B => B.Include(x => x.BloodType)
                .Include(x => x.BloodBank));

        }

        public IEnumerable<Platelets> GetAllDeleted()
        {
            return _unitOfWork.Platelets.FindAll(b => b.IsDeleted || b.ExpirationDate <= DateTime.Now,
                include: x => x.Include(B => B.BloodType)
                .Include(b => b.BloodBank));

        }

        public IEnumerable<PlateletsesResponse> GetAllInType(int BloodTypeId)
        {
            var result = GetAll();

            var response = result.Where(b => b.BloodTypeId == BloodTypeId).Adapt<IEnumerable<PlateletsesResponse>>();

            if (!response.Any()) return null;

            return response;
        }

        public IEnumerable<PlateletsesResponse> GetAllInTypeInBank(int BloodTypeId, int BankId)
        {
            var result = GetAll();

            var response = result.Where(b => b.BloodTypeId == BloodTypeId && b.BloodBankId == BankId).Adapt<IEnumerable<PlateletsesResponse>>();

            if (!response.Any()) return null;

            return response;
        }




        public Platelets? FindById(int id)
        {
            return  _unitOfWork.Platelets.Find(B => B.Id == id);
        }



        public int Add(Platelets bag)
        {
            _unitOfWork.Platelets.Add(bag);

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
