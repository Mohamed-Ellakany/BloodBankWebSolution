namespace BloodBankWeb.Core.ViewModels
{
    public class HomeViewModel
    {
        public int NumberOfBloodBags { get; set; }

        public int NumberOfDonors { get; set; }

        public IEnumerable<(string BloodTypeName, int Count)> BloodCounts { get; set; }


    }
}
