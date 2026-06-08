using BloodBank.Application.Services.BloodBanks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BloodBanksController(IBloodBankServices bankServices) : ControllerBase
    {
        private readonly IBloodBankServices _bankServices = bankServices;


        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _bankServices.GetAllForApp();


            return response is null ? NotFound() : Ok(response);
        }

        [HttpGet("{CityId}")]
        public IActionResult GetAll(int CityId) 
        {
            var banks = _bankServices.GetAllInCity(CityId);


            return banks is null ? NotFound() : Ok(banks);

            
        }
        
    
    }
}
