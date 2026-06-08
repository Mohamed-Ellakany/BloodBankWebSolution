using BloodBank.Application.Services.BloodTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BloodTypesController(IBloodTypesServices typesServices) : ControllerBase
    {
        private readonly IBloodTypesServices _typesServices = typesServices;

        [HttpGet]
        public  IActionResult GetAll()
        {
            var res = _typesServices.GetAll();
             return Ok(res);
        }
        

        [HttpGet("{id}")]
        public  IActionResult GetById(int id)
        {
             return Ok(_typesServices.GetById(id));
        }

        

    
    }
}
