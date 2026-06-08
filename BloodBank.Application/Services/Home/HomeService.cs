using BloodBank.Application.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Services.Home
{
    public class HomeService : IHomeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<(string bloodTypeName, int count)> GetValues()
        {
            return _unitOfWork.BloodTypes.GetAll()
             .Select(bt => new
             {
                 BloodTypeName = bt.Name,
                 Count = _unitOfWork.BloodBags.FindAll(b => !b.IsDeleted && b.ExpirationDate > DateTime.Now).Count(bb => bb.BloodTypeId == bt.Id)
             })
             .ToList()
             .Select(b => (b.BloodTypeName, b.Count))
             .ToList();

        }

        public int GetCountOfDonors()
        {
            return _unitOfWork.Donors.Count();
        }

        public int GetCountOfAll()
        {
            return _unitOfWork.BloodBags.FindAll(b => !b.IsDeleted && b.ExpirationDate > DateTime.Now).Count();
        }

        public List<ChartDto> GetSelectedValues()
        {
            var data = _unitOfWork.BloodTypes.GetAll()
             .Select(bt => new ChartDto(bt.Name, _unitOfWork.BloodBags.Count(bb => bb.BloodTypeId == bt.Id))).ToList();


            return data;
        }
    }
}
