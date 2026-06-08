using BloodBank.Application.Services.Plasmas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloodBankWeb.Controllers
{
    public class DeletedPlasmaController : Controller
    {

        private readonly IPlasmaService _plasmaService;
        private readonly IMapper _mapper;

        public DeletedPlasmaController(IUnitOfWork unitOfWork, IMapper mapper, IPlasmaService plasmaService)
        {
            _mapper = mapper;
            _plasmaService = plasmaService;
        }


        public IActionResult Index()
        {
            var plasmas = _plasmaService.GetAllDeleted();
            //var plasmas = _unitOfWork.Plasmas.FindAll(b => b.IsDeleted || b.ExpirationDate <= DateTime.Now, include: x => x.Include(B => B.BloodType).Include(b => b.Donor).Include(b => b.BloodBank));
            var viewModel = _mapper.Map<IEnumerable<PlasmaViewModel>>(plasmas);

            return View(viewModel);
        }
    }
}
