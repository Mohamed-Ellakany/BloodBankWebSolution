using BloodBank.Application.Services.Blood;
using BloodBank.Application.Services.Plasmas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlasmasController(IPlasmaService plasmaService) : ControllerBase
    {


        private readonly IPlasmaService _plasmaService = plasmaService;

        [HttpGet("AllWithType")]
        public IActionResult GetAllInType(int TypeId)
        {
            var result = _plasmaService.GetAllInType(TypeId);

            if (result is null) return Result.Failure(UserErrors.NoPlasmaWithType).ToProblem();

            return Ok(result);
        }

        [HttpGet("AllInBankWithType")]
        public IActionResult GetAllInTypeInBank(int TypeId, int BloodBankId)
        {
            var result = _plasmaService.GetAllInTypeInBank(TypeId, BloodBankId);

            if (result is null) return Result.Failure(UserErrors.NoPlasmaWithTypeInBank).ToProblem();

            return Ok(result);
        }
    }
}
