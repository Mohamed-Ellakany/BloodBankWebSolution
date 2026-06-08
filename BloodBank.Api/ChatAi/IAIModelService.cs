namespace BloodBank.Api.ChatAi
{
    public interface IAIModelService
    {
        Task<string> GetAiResponse(string userMessage);

    }
}
