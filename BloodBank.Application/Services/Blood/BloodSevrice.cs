using BloodBank.Application.Common.ModelContracts.BloodBag;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Services.Blood
{
    public class BloodSevrice : IBloodSevrice
    {

        private readonly IUnitOfWork _unitOfWork;
        public BloodSevrice(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<BloodBag> GetAll()
        {

            return _unitOfWork.BloodBags.FindAll(b => !b.IsDeleted && b.ExpirationDate > DateTime.Now,
                include: B => B.Include(x => x.BloodType)
                .Include(x => x.Donor)
                .Include(x => x.BloodBank));

        }

        public IEnumerable<BloodBag> GetAllDeleted()
        {
            return _unitOfWork.BloodBags.FindAll(b => b.IsDeleted || b.ExpirationDate <= DateTime.Now,
                include: x => x.Include(B => B.BloodType)
                .Include(b => b.Donor)
                .Include(b => b.BloodBank));

        }

        public IEnumerable<BloodBagResponse> GetAllInType(int BloodTypeId)
        {
            var result = GetAll();

            var response = result.Where(b=>b.BloodTypeId == BloodTypeId).Adapt<IEnumerable< BloodBagResponse>>();

            if(!response.Any()) return null;


            return response;

        }
        
        public IEnumerable<BloodBagResponse> GetAllInTypeInBank(int BloodTypeId , int BankId)
        {
            var result = GetAll();

            var response = result.Where(b=>b.BloodTypeId == BloodTypeId && b.BloodBankId ==BankId).Adapt<IEnumerable< BloodBagResponse>>();

            if(!response.Any()) return null;

            return response;
        }


        public  BloodBag? FindById(int id)
        {
           return  _unitOfWork.BloodBags.Find(B=>B.Id == id);
        }



        public int Add(BloodBag bag)
        {
            _unitOfWork.BloodBags.Add(bag);

            return _unitOfWork.Complete();
        }

        public int? Buy(int id)
        {
            var bag = FindById(id);

            if (bag is null)
                return null;
            
            if (bag.IsDeleted)
               return null;

            bag.IsDeleted = true;

           return _unitOfWork.Complete();
        }



    }
}
