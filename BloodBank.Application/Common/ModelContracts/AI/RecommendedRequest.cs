namespace BloodBank.Application.Common.ModelContracts.AI
{
    public class RecommendedRequest
    {
        public string Governorate { get; set; }
        public string blood_type { get; set; }
        public int Quantity { get; set; }
    }
}
