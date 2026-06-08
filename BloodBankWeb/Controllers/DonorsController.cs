
using BloodBank.Application.Services.BloodBanks;
using BloodBank.Application.Services.BloodTypes;
using BloodBank.Application.Services.City;
using BloodBank.Application.Services.Donors;
using BloodBankWeb.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BloodBankWeb.Controllers
{
    
    [Authorize(Roles = AppRoles.subAdmin)]
    public class DonorsController : Controller
    {
        private readonly IDonorsServices _donorServices;
        private readonly IBloodTypesServices _bloodTypesServices;
        private readonly IBloodBankServices _bloodBankServices;
        private readonly ICityServices _cityServices;
        private readonly IMapper _mapper;

        public DonorsController(IUnitOfWork unitOfWork, IMapper mapper, IDonorsServices donorServices, IBloodBankServices bloodBankServices, IBloodTypesServices bloodTypesServices, ICityServices cityServices)
        {
            _mapper = mapper;
            _donorServices = donorServices;
            _bloodBankServices = bloodBankServices;
            _bloodTypesServices = bloodTypesServices;
            _cityServices = cityServices;
        }

        public IActionResult Index()
        {
            var donors =_donorServices.GetAll();
                //_unitOfWork.Donors.FindAll(predicate:x=>x.Age==x.Age , include: d => d.Include(x => x.DonorBanks).ThenInclude(x => x.BloodBank).Include(x => x.BloodType));

            //var donors= _context.Donors
            //    .Include(d=>d.DonorBanks)
            //    .ThenInclude(d=>d.BloodBank)
            //    .Include(d=>d.BloodType).ToList();

            var viewModel = _mapper.Map<IEnumerable<DonorViewModel>>(donors);
            
            return View(viewModel);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var ViewModel = PopulateViewModel();


            return View("Form", ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DonorFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel = PopulateViewModel(viewModel);
                return View("Form", viewModel);
            }

            var donor = _mapper.Map<Donor>(viewModel);

            donor.DonorBanks.Add(new DonorBank { BloodBankId = viewModel.BloodBankId });

            _donorServices.Add(donor);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> CheckNationalId(DonorFormViewModel model)
        {
            bool isExist = _donorServices.CheckNational(model.Id, model.NationalId);

            //var user = model.Id == 0 ?  _unitOfWork.Donors.Find(u => u.NationalId == model.NationalId)
            //    :  _unitOfWork.Donors.FindAll(u => u.Id != model.Id).FirstOrDefault(u => u.NationalId == model.NationalId);

            //var user = model.Id == 0 ? await _context.Donors.FirstOrDefaultAsync(u => u.NationalId == model.NationalId)
            //    : await _context.Donors.Where(u => u.Id != model.Id).FirstOrDefaultAsync(u => u.NationalId == model.NationalId);


            //var isExist = user is null;
            return Json(isExist);
        }

    

        private DonorFormViewModel PopulateViewModel(DonorFormViewModel? model = null)
        {
            DonorFormViewModel viewModel = model is null ? new DonorFormViewModel() : model;

            //var BloodTypes = _context.BloodTypes.OrderBy(BT => BT.Name).ToList();
            //var BloodBanks = _context.BloodBanks.OrderBy(BB => BB.Name).ToList();
            var BloodTypes = _bloodTypesServices.GetAllOrdered();

            var BloodBanks = _bloodBankServices.GetAllOrdered();
            var Cities = _cityServices.GetAll();


            viewModel.BloodTypes = _mapper.Map<IEnumerable<SelectListItem>>(BloodTypes);
            viewModel.BloodBanks = _mapper.Map<IEnumerable<SelectListItem>>(BloodBanks);
            viewModel.Cites = _mapper.Map<IEnumerable<SelectListItem>>(Cities);
         


            return viewModel;
        }


        [AjaxOnly]
        public IActionResult GetBanks(int cityId)
        {

            var Banks = _bloodBankServices.GetAllInCity(cityId);

            var BansksSelected = Banks.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();

            return Ok(BansksSelected);
        }

    }
}
