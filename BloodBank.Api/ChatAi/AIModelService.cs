

using System.Text.Json;

namespace BloodBank.Api.ChatAi
{
    public class AIModelService :IAIModelService
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public AIModelService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<string> GetAiResponse(string userMessage)
        {
            var apiUrl = _configuration["AIModel:ApiUrl"];

            var requestData = new
            {
                contents = new[]
                {
                new
                {
                    parts = new[]
                    {
                        new { text = userMessage }
                    }
                }
            }
            };

            var json = JsonSerializer.Serialize(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(apiUrl, content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            // Simple parsing - adjust based on your actual API response
            using JsonDocument doc = JsonDocument.Parse(responseContent);
            var text = doc.RootElement
                .GetProperty("candidates")[0]
                .GetProperty("content")
                .GetProperty("parts")[0]
                .GetProperty("text")
                .GetString();

            return text ?? "I didn't understand that.";
        }
    }
}