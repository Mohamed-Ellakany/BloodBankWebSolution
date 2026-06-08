using BloodBank.Application.Common.ModelContracts.AI;
using BloodBank.Application.Services.AI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AiController(IAiServices aiServices) : ControllerBase
    {
        private readonly IAiServices _aiServices = aiServices;



        [HttpPost("recommended")]
        [Authorize]
        public async Task<ActionResult> GetRecommended([FromBody] RecommendedRequest request)
        {
            var result = await _aiServices.GetRecommended(request);

            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();

        }

        [HttpPost("predict")]
        [Authorize]
        public async Task<ActionResult> GetPredict([FromBody] DiseaseRequest request)
        {
            var result = await _aiServices.GetPredict(request);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();

        }
    }
}
