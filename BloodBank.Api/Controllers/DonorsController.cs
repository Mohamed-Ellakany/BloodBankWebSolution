using BloodBank.Application.Common.ModelContracts.Donors;
using BloodBank.Application.Services.Donors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DonorsController(IDonorsServices donorsServices) : ControllerBase
    {
        private readonly IDonorsServices _donorsServices = donorsServices;


        [HttpGet]
        public IActionResult GetAll() 
        {
            return Ok(_donorsServices.GetAllForApp());
        }
    
    
    }
}
