
using BloodBank.Application.Common.DTOs;
using BloodBank.Application.Services.Home;
using BloodBankWeb.Helpers;
using BloodBankWeb.Models;

using System.Diagnostics;

namespace BloodBankWeb.Controllers
{
    [Authorize(Roles = $"{AppRoles.Admin},{AppRoles.subAdmin}")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
private readonly IHomeService _homeService;

        public HomeController(ILogger<HomeController> logger,  IHomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
        }

        public IActionResult Index()
        {
            // Fetch all blood types with their blood bag counts
            var bloodCounts = _homeService.GetValues();

            //var bloodCounts = _unitOfWork.BloodTypes.GetAll()
            //    .Select(bt => new
            //    {
            //        BloodTypeName = bt.Name,
            //        Count = _unitOfWork.BloodBags.FindAll(b => !b.IsDeleted && b.ExpirationDate > DateTime.Now).Count(bb => bb.BloodTypeId == bt.Id)
            //    })
            //    .ToList()
            //    .Select(b => (b.BloodTypeName, b.Count))
            //    .ToList();

            // Prepare the view model
            var viewModel = new HomeViewModel
            {
                NumberOfBloodBags = _homeService.GetCountOfAll(),

                NumberOfDonors =_homeService.GetCountOfDonors(),

                BloodCounts = bloodCounts
            };

            return View(viewModel);
        }


        [AjaxOnly]
        public IActionResult GetDataOfChart()
        {
            //var data = _unitOfWork.BloodTypes.GetAll()
            //    .Select(bt => new ChartViewModel
            //    {
            //        Label = bt.Name,
            //        Value = _unitOfWork.BloodBags.Count(bb => bb.BloodTypeId == bt.Id)
            //    }).ToList();

            var data = _homeService.GetSelectedValues();

            var result = data.Select(dto => new ChartViewModel
            {
                Label = dto.Label,
                Value = dto.Value
          
            }).ToList();

            return Ok(result);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
