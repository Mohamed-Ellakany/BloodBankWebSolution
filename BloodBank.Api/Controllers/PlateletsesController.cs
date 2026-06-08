using BloodBank.Application.Services.Plateletses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlateletsesController(IPlateletsService plateletsService) : ControllerBase
    {
        private readonly IPlateletsService _plateletsService = plateletsService;

        [HttpGet("AllWithType")]
        public IActionResult GetAllInType(int TypeId)
        {
            var result = _plateletsService.GetAllInType(TypeId);

            if (result is null) return Result.Failure(UserErrors.NoPlateletsesWithType).ToProblem();

            return Ok(result);
        }

        [HttpGet("AllInBankWithType")]
        public IActionResult GetAllInTypeInBank(int TypeId, int BloodBankId)
        {
            var result = _plateletsService.GetAllInTypeInBank(TypeId, BloodBankId);

            if (result is null) return Result.Failure(UserErrors.NoPlateletsesWithTypeInBank).ToProblem();

            return Ok(result);
        }

    }
}
