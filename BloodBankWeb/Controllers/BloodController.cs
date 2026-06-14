using BloodBank.Application.Services.Blood;
using BloodBank.Application.Services.BloodBanks;
using BloodBank.Application.Services.BloodTypes;
using BloodBank.Application.Services.DonorBanks;
using BloodBank.Application.Services.Donors;
using BloodBank.Domain.Entities;
using BloodBankWeb.Helpers;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BloodBankWeb.Controllers
{
    [Authorize(Roles = AppRoles.subAdmin)]
    public class BloodController(IMapper mapper, IBloodSevrice bloodSevrice, IDonorsServices donorsServices, IBloodTypesServices bloodTypesServices, IBloodBankServices bloodBankServices, IDonorBanksServices donorBanksServices, UserManager<ApplicationUser> userManager) : Controller
    {
        private readonly IBloodSevrice _bloodSevrice = bloodSevrice;
        private readonly IDonorsServices _donorsServices = donorsServices;
        private readonly IBloodTypesServices _bloodTypesServices = bloodTypesServices;
        private readonly IBloodBankServices _bloodBankServices = bloodBankServices;
        private readonly IDonorBanksServices _donorBanksServices = donorBanksServices;
        private readonly IMapper _mapper = mapper;
        private readonly UserManager<ApplicationUser> _userManager = userManager;


        ApplicationUser? _user;

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _user = await _userManager.GetUserAsync(User);
            ViewBag.UserBloodBankId = _user?.BloodBankId;
            await next();
        }

        [HttpGet]
        [Authorize(Roles = AppRoles.subAdmin)]
        public IActionResult Index()
        {
            //ViewBag.UserBloodBankId = _userManager.GetUserAsync(User).Result!.BloodBankId;
            
            var bloodBags = _bloodSevrice.GetAll();

            var BloodView = _mapper.Map<IEnumerable<BloodViewModel>>(bloodBags);

            return View(BloodView);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var ViewModel = PopulateViewModel();

            return View("Form", ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BloodFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel = PopulateViewModel(viewModel);
                return View("Form", viewModel);
            }

            //check blood type 
            var Donor =_donorsServices.GetById(viewModel.DonorId);

            if (Donor.BloodBags.Any() )
            {

                //todo : check last date of donation
                if (Donor.DonationDate.AddDays(90) > DateTime.Now)
                {
                    ModelState.AddModelError(nameof(viewModel.BloodTypeId), errorMessage: "90 days must pass since the last donation ");
                    return View("Form", PopulateViewModel(viewModel));
                }
            }

            var bloodBag = _mapper.Map<BloodBag>(viewModel);

            bloodBag.BloodBankId = _user!.BloodBankId;

            var result = _bloodSevrice.Add(bloodBag);

            if (result != 0)
            {
                Donor.DonationDate = DateTime.Now;
                _donorsServices.UpdateDonationDate(Donor);
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public IActionResult Buy(int Id)
        {
          var resutlt=  _bloodSevrice.Buy(Id);

            if (resutlt is null)
            {
                return NotFound();
            }
         
            return RedirectToAction(nameof(Index));
        }

        [AjaxOnly]
        public IActionResult GetDonors(int BankId) 
        {
            var donors =_donorBanksServices.GetAllInBank(BankId);

            var donorSelectList = donors.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();

            return Ok(donorSelectList);
        }

        private BloodFormViewModel PopulateViewModel(BloodFormViewModel? model = null)
        {
            BloodFormViewModel viewModel = model is null ? new BloodFormViewModel() : model;

            var BloodTypes = _bloodTypesServices.GetAllOrdered();

            var Donors = _donorsServices.GetAllInBank(_user!.BloodBankId);

            viewModel.Donors = _mapper.Map<IEnumerable<SelectListItem>>(Donors);

            viewModel.BloodTypes = _mapper.Map<IEnumerable<SelectListItem>>(BloodTypes);

            return viewModel;
        }

       
        public async Task<IActionResult> ValidateBloodType(int donorId, int bloodTypeId)
        {
            var donor = _donorsServices.GetById(donorId);

            //var donor = await _context.Donors
            //    .Include(d => d.BloodType)
            //    .FirstOrDefaultAsync(d => d.Id == donorId);

            if (donor == null || donor.BloodType.Id !=bloodTypeId)
            {
                return Json(false);
            }

            return Json(true);
        }


    }
}
