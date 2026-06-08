
using AutoMapper;
using BloodBank.Application.Services.Blood;
using BloodBank.Application.Services.BloodBanks;
using BloodBank.Application.Services.BloodTypes;
using BloodBank.Application.Services.DonorBanks;
using BloodBank.Application.Services.Donors;
using BloodBank.Application.Services.Plasmas;
using BloodBank.Domain.Entities;
using BloodBankWeb.Core.ViewModels;
using BloodBankWeb.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BloodBankWeb.Controllers
{
    [Authorize(Roles = AppRoles.subAdmin)]
    public class PlasmaController(IUnitOfWork unitOfWork,UserManager<ApplicationUser> userManager ,IMapper mapper, IPlasmaService plasmaService, IDonorsServices donorsServices, IBloodTypesServices bloodTypesServices, IBloodBankServices bloodBankServices, IDonorBanksServices donorBanksServices, IBloodSevrice bloodSevrice) : Controller
	{
        private readonly IDonorsServices _donorsServices = donorsServices;
        private readonly IPlasmaService _plasmaService = plasmaService;
        private readonly IBloodTypesServices _bloodTypesServices = bloodTypesServices;
        private readonly IBloodBankServices _bloodBankServices = bloodBankServices;
        private readonly IDonorBanksServices _donorBanksServices = donorBanksServices;
        private readonly IBloodSevrice _bloodSevrice = bloodSevrice;
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly IMapper _mapper = mapper;


        ApplicationUser? _user;

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _user = await _userManager.GetUserAsync(User);
            ViewBag.UserBloodBankId = _user?.BloodBankId;
            await next();
        }

        [HttpGet]
        public IActionResult Index()
		{
            
            var plasmas = _plasmaService.GetAll();

            var plasmaViews = _mapper.Map<IEnumerable<PlasmaViewModel>>(plasmas);

            return View(plasmaViews);
		}

        [HttpGet]
        public IActionResult Create() 
        {
            var viewModel = PopulateViewModel();
            return View("Form", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlasmaFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel = PopulateViewModel(viewModel);
                return View("Form", viewModel);
            }

            //check blood type 
            //var Donor = _unitOfWork.Donors
            //              .Find(d => d.Id == viewModel.DonorId
            //              , include: B => B.Include(x => x.BloodType)
            //              .Include(x => x.Plasmas));
            var bloodbags = _bloodSevrice.GetAllInTypeInBank(viewModel.BloodTypeId, _user!.BloodBankId);
            
            int SumOfBloodBagsWithType = bloodbags.Sum(b => b.Quantity)/2;

            //if (Donor?.BloodType.Id != viewModel.BloodTypeId)
            //{
            //    ModelState.AddModelError(nameof(viewModel.BloodTypeId), errorMessage: "it's not your blood type");
            //    return View("Form", PopulateViewModel(viewModel));
            //}

            if (viewModel.Quantity >= SumOfBloodBagsWithType)
            {
                    ModelState.AddModelError(nameof(viewModel.Quantity), errorMessage: "Quantity must be more than quantity of blood bags / 2");
                    return View("Form", PopulateViewModel(viewModel));
            }
             var Plasma = _mapper.Map<Plasma>(viewModel);


            Plasma.BloodBankId = _user!.BloodBankId;

            _plasmaService.Add(Plasma);

            
            return RedirectToAction(nameof(Index));
        
        }



        [HttpPost]
        public IActionResult Buy(int Id)
        {
            _plasmaService.Buy(Id);

            return RedirectToAction(nameof(Index));
        }


        private PlasmaFormViewModel PopulateViewModel(PlasmaFormViewModel? model = null)
        {
            PlasmaFormViewModel viewModel = model is null ? new PlasmaFormViewModel() : model;

            var BloodTypes = _bloodTypesServices.GetAllOrdered();
            //var BloodBanks = _bloodBankServices.GetAllOrdered();

            


            viewModel.BloodTypes = _mapper.Map<IEnumerable<SelectListItem>>(BloodTypes);
            //viewModel.BloodBanks = _mapper.Map<IEnumerable<SelectListItem>>(BloodBanks);


            return viewModel;
        }












    }
}
