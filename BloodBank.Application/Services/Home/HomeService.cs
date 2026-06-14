using BloodBank.Application.Common.DTOs;

namespace BloodBank.Application.Services.Home
{
    public class HomeService : IHomeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DashboardSummaryDto GetDashboardSummary()
        {
            var activeBloodBagCounts = _unitOfWork.BloodBags
                .GetQueryable()
                .AsNoTracking()
                .Where(bag => !bag.IsDeleted && bag.ExpirationDate > DateTime.Now)
                .GroupBy(bag => bag.BloodTypeId)
                .Select(group => new { BloodTypeId = group.Key, Count = group.Count() })
                .ToDictionary(item => item.BloodTypeId, item => item.Count);

            var bloodCounts = _unitOfWork.BloodTypes
                .GetQueryable()
                .AsNoTracking()
                .OrderBy(bloodType => bloodType.Name)
                .Select(bloodType => new { bloodType.Id, bloodType.Name })
                .ToList()
                .Select(bloodType => new ChartDto(
                    bloodType.Name,
                    activeBloodBagCounts.GetValueOrDefault(bloodType.Id)))
                .ToList();

            var numberOfBloodBags = activeBloodBagCounts.Values.Sum();
            var numberOfDonors = _unitOfWork.Donors.GetQueryable().AsNoTracking().Count();

            return new DashboardSummaryDto(numberOfBloodBags, numberOfDonors, bloodCounts);
        }
    }
}
