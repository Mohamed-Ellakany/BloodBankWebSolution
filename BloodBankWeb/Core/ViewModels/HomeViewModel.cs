namespace BloodBankWeb.Core.ViewModels
{
    public class HomeViewModel
    {
        public int NumberOfBloodBags { get; set; }

        public int NumberOfDonors { get; set; }

        public IEnumerable<ChartDto> BloodCounts { get; set; } = [];
    }
}
