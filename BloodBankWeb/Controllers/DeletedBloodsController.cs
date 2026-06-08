using BloodBank.Application.Services.Blood;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloodBankWeb.Controllers
{
    public class DeletedBloodsController : Controller
    {
        private readonly IBloodSevrice _bloodService;
        private readonly IMapper _mapper;

        public DeletedBloodsController( IMapper mapper, IBloodSevrice bloodService)
        {
            _mapper = mapper;
            _bloodService = bloodService;
        }


        public IActionResult Index()
        {
            var bloodBags =_bloodService.GetAllDeleted();
            var BloodView = _mapper.Map<IEnumerable<BloodViewModel>>(bloodBags);

            return View(BloodView);
        }
    }
}
