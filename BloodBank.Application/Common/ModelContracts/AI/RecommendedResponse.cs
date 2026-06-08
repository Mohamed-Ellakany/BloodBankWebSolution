using System.Text.Json.Serialization;

namespace BloodBank.Application.Common.ModelContracts.AI
{
    public class RecommendedResponse
    {

         [JsonPropertyName("BloodBank_Name")]
        public string BloodBankName { get; set; }

        [JsonPropertyName("Blood_Type")]
        public string BloodType { get; set; }

        public string Governorate { get; set; }
    }
}
