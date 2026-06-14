using AutoMapper;
using BloodBank.Application.Services.Blood;
using BloodBank.Application.Services.BloodBanks;
using BloodBank.Application.Services.BloodTypes;
using BloodBank.Application.Services.Donors;
using BloodBank.Domain.Entities;
using BloodBankWeb.Core.ViewModels;
using BloodBankWeb.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BloodBank.Application.Services.Plateletses;
using BloodBank.Application.Services.DonorBanks;

namespace BloodBankWeb.Controllers
{
    [Authorize(Roles = AppRoles.subAdmin)]
    public class PlateletsController(IMapper mapper, IPlateletsService plateletsService, IBloodTypesServices bloodTypesServices, IBloodBankServices bloodBankServices, IBloodSevrice bloodSevrice) : Controller
	{
        private readonly IPlateletsService _plateletsService = plateletsService;
        private readonly IBloodTypesServices _bloodTypesServices = bloodTypesServices;
        private readonly IBloodBankServices _bloodBankServices = bloodBankServices;
        private readonly IMapper _mapper = mapper;
        private readonly IBloodSevrice _bloodSevrice = bloodSevrice;

        [HttpGet]
        public IActionResult Index()
		{
            var platelets = _plateletsService.GetAll();

            //var platelets = _unitOfWork.Platelets
            //    .FindAll(b => !b.IsDeleted && b.ExpirationDate > DateTime.Now,
            //    include: B => B.Include(x => x.BloodType)
            //    .Include(x => x.Donor)
            //    .Include(x => x.BloodBank)); 


            var plateletsView = _mapper.Map<IEnumerable<PlateletsViewModel>>(platelets);

            return View(plateletsView); 

		}

        [HttpGet]
        public IActionResult Create()
        {
            var ViewModel = PopulateViewModel();

            return View("Form", ViewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PlateletsFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel = PopulateViewModel(viewModel);
                return View("Form", viewModel);
            }

            //check blood type 
            //var Donor = _unitOfWork.Donors
            //      .Find(d => d.Id == viewModel.DonorId
            //      , include: B => B.Include(x => x.BloodType)
            //      .Include(x => x.Platelets));

            var bloodbags = _bloodSevrice.GetAllInTypeInBank(viewModel.BloodTypeId, viewModel.BloodBankId) ?? [];


            if (viewModel.Quantity > Math.Floor((decimal)bloodbags.Count() / 6))
            {
                ModelState.AddModelError(nameof(viewModel.Quantity), errorMessage: "Quantity must be less than quantity of blood bags / 6 ");
                return View("Form", PopulateViewModel(viewModel));

            }

            var platelet = _mapper.Map<Platelets>(viewModel);

            //    _unitOfWork.Platelets.Add(platelet);
            //_unitOfWork.Complete();


            var result = _plateletsService.Add(platelet);



            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        public IActionResult Buy(int Id)
        {
            //var bag = _unitOfWork.Platelets.Find(b => b.Id == Id);

            //if (bag == null)
            //    return NotFound();

            //bag.IsDeleted = true;


            //_unitOfWork.Complete();

            _plateletsService.Buy(Id);

            return RedirectToAction(nameof(Index));
        }

        private PlateletsFormViewModel PopulateViewModel(PlateletsFormViewModel? model = null)
        {
            PlateletsFormViewModel viewModel = model is null ? new PlateletsFormViewModel() : model;

            //var BloodTypes = _unitOfWork.BloodTypes.GetAllOrderd(orderBy: BT => BT.Name);
            //var BloodBanks = _unitOfWork.BloodBanks.GetAllOrderd(orderBy: BT => BT.Name);
            //var Donors = _unitOfWork.Donors.GetAllOrderd(orderBy: BT => BT.Name);
            var BloodTypes = _bloodTypesServices.GetAllOrdered();

            var BloodBanks = _bloodBankServices.GetAllOrdered();


            viewModel.BloodTypes = _mapper.Map<IEnumerable<SelectListItem>>(BloodTypes);
            viewModel.BloodBanks = _mapper.Map<IEnumerable<SelectListItem>>(BloodBanks);
            //viewModel.Donors = _mapper.Map<IEnumerable<SelectListItem>>(Donors);

            return viewModel;
        }

       

      
    }
}
