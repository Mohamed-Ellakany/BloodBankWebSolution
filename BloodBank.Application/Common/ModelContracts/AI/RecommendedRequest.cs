namespace BloodBank.Application.Common.ModelContracts.AI
{
    public class RecommendedRequest
    {
        public string Governorate { get; set; } = string.Empty;
        public string blood_type { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
