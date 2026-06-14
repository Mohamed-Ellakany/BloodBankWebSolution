using System.Text.Json.Serialization;

namespace BloodBank.Application.Common.ModelContracts.AI
{
    public class RecommendedResponse
    {

         [JsonPropertyName("BloodBank_Name")]
        public string BloodBankName { get; set; } = string.Empty;

        [JsonPropertyName("Blood_Type")]
        public string BloodType { get; set; } = string.Empty;

        public string Governorate { get; set; } = string.Empty;
    }
}
