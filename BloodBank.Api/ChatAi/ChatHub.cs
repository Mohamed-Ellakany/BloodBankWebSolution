using Microsoft.AspNetCore.SignalR;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BloodBank.Api.ChatAi;
using Microsoft.AspNetCore.Authorization;

public sealed class ChatHub : Hub
{

    private readonly AIModelService _chatService;

    public ChatHub(AIModelService chatService)
    {
        _chatService = chatService;
    }
    public async Task SendMessage(string userMessage)
    {
        // Get the connection ID to send responses back to the same user
        var connectionId = Context.ConnectionId;

        // Process the message and get AI response
        var aiResponse = await _chatService.GetAiResponse(userMessage);

        // Send the response back to the user
        await Clients.Client(connectionId).SendAsync("ReceiveMessage", aiResponse);
    }
    
}