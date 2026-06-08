using BloodBank.Application.Services.Blood;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BloodBagsController(IBloodSevrice bloodSevrice) : ControllerBase
    {
        private readonly IBloodSevrice _bloodSevrice = bloodSevrice;

        [HttpGet("AllWithType")]
        public IActionResult GetAllInType(int TypeId)
        {
            var result = _bloodSevrice.GetAllInType(TypeId);

            if (result is null) return Result.Failure(UserErrors.NoBloodBagWithTpye).ToProblem();

            return Ok(result);
        }

        [HttpGet("AllInBankWithType")]
        public IActionResult GetAllInTypeInBank(int TypeId, int BloodBankId)
        {
            var result = _bloodSevrice.GetAllInTypeInBank(TypeId, BloodBankId);

            if (result is null) return Result.Failure(UserErrors.NoBloodBagWithTpyeInBank).ToProblem();

            return Ok(result);
        }
    }
}
