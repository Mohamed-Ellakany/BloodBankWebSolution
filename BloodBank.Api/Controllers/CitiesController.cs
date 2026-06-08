using BloodBank.Application.Services.City;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController(ICityServices cityServices) : ControllerBase
    {
        private readonly ICityServices _cityServices = cityServices;

        [HttpGet]
        public IActionResult GetAll()
        {
            var cities = _cityServices.GetAll();
            if (cities == null || !cities.Any())
            {
                return NotFound("No cities found.");
            }
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var city = _cityServices.GetById(id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);

        }
    }
}
