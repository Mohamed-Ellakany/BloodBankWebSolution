using BloodBank.Application.Services.Plateletses;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankWeb.Controllers
{
    public class DeletedPlateletsController : Controller
    {
        private readonly IPlateletsService _plateletsService;
        private readonly IMapper _mapper;

        public DeletedPlateletsController(IUnitOfWork unitOfWork, IMapper mapper, IPlateletsService plateletsService)
        {
            _mapper = mapper;
            _plateletsService = plateletsService;
        }


        public IActionResult Index()
        {
            var platelets = _plateletsService.GetAllDeleted();

            //var platelets = _unitOfWork.Platelets.FindAll(b => b.IsDeleted || b.ExpirationDate <= DateTime.Now, include: x => x.Include(B => B.BloodType).Include(b => b.Donor).Include(b => b.BloodBank));
            var viewModel = _mapper.Map<IEnumerable<PlateletsViewModel>>(platelets);

            return View(viewModel);
        }
    }
}
