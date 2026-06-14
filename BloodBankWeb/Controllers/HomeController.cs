
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
            var dashboardSummary = _homeService.GetDashboardSummary();

            var viewModel = new HomeViewModel
            {
                NumberOfBloodBags = dashboardSummary.NumberOfBloodBags,
                NumberOfDonors = dashboardSummary.NumberOfDonors,
                BloodCounts = dashboardSummary.BloodCounts
            };

            return View(viewModel);
        }


        [AjaxOnly]
        public IActionResult GetDataOfChart()
        {
            var data = _homeService.GetDashboardSummary().BloodCounts;

            var result = data.Select(dto => new ChartViewModel
            {
                Label = dto.BloodTypeName,
                Value = dto.Count

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
