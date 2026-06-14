namespace BloodBank.Application.Common.DTOs
{
    public record DashboardSummaryDto(
        int NumberOfBloodBags,
        int NumberOfDonors,
        IReadOnlyList<ChartDto> BloodCounts
    );
}
