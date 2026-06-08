using BloodBank.Application.Common.ModelContracts.Donors;
using BloodBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Services.Donors
{
    public class DonorsServices : IDonorsServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public DonorsServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Donor> GetAll()
        {
            return _unitOfWork.Donors.FindAll(predicate: x => x.Age == x.Age, include: d => d.Include(x => x.DonorBanks).ThenInclude(x => x.BloodBank).Include(x => x.BloodType));

        }

        public IEnumerable<DonorResponse> GetAllForApp()
        {
            return _unitOfWork.Donors.FindAll(predicate: x => x.DonationDate.AddDays(60) <= DateTime.UtcNow, include: d => d.Include(x => x.DonorBanks).ThenInclude(x => x.BloodBank).Include(x => x.BloodType)).Adapt<IEnumerable<DonorResponse>>();

        }
        public IEnumerable<Donor> GetAllInBank(int BankId)
        {
            return _unitOfWork.Donors.FindAll(predicate: x => x.DonorBanks.Any(b => b.BloodBankId == BankId), include: d => d.Include(x => x.DonorBanks).ThenInclude(x => x.BloodBank).Include(x => x.BloodType));
        }


        public bool CheckNational(int? id, string nationalId)
        {
            var user = id == 0 ? _unitOfWork.Donors.Find(u => u.NationalId == nationalId)
              : _unitOfWork.Donors.FindAll(u => u.Id != id).FirstOrDefault(u => u.NationalId == nationalId);

            var isExist = user is null;

            return isExist;
        }


        public Donor? GetById(int id)
        {
            return _unitOfWork.Donors
                .Find(d => d.Id == id
                , include: B => B.Include(x => x.BloodType)
                .Include(x => x.BloodBags));
        }


        public int Add(Donor donor)
        {
            _unitOfWork.Donors.Add(donor);

            return _unitOfWork.Complete();
        }

        public void UpdateDonationDate(Donor donor)
        {
            _unitOfWork.Donors.Update(donor);
            _unitOfWork.Complete();
        }

    }
}
