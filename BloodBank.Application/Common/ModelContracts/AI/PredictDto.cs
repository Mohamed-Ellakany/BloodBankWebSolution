namespace BloodBank.Application.Common.ModelContracts.AI
{
    public class PredictDto
    {
        public string Disease { get; set; } = string.Empty;
        public double? Prevalence { get; set; }
    }

    
}
