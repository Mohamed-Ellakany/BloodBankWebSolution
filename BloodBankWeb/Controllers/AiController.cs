using BloodBank.Application.Services.AI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AiController(IAiServices aiServices) : ControllerBase
    {

        private readonly IAiServices _aiServices = aiServices;

        






    }
}
