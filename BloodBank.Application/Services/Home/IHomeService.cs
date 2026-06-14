using BloodBank.Application.Common.DTOs;

namespace BloodBank.Application.Services.Home
{
    public interface IHomeService
    {
        DashboardSummaryDto GetDashboardSummary();
    }
}
