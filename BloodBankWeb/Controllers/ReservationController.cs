using BloodBank.Application.Services.BloodBanks;
using BloodBank.Application.Services.BloodTypes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace BloodBankWeb.Controllers
{
    public class ReservationController(ApplicationDbContext dbContext, IMapper mapper, UserManager<ApplicationUser> userManager, IBloodBankServices bloodBankServices, IBloodTypesServices bloodTypesServices) : Controller
    {
        private readonly ApplicationDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly IBloodBankServices _bloodBankServices = bloodBankServices;
        private readonly IBloodTypesServices _bloodTypesServices = bloodTypesServices;

        ApplicationUser? _user;

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _user = await _userManager.GetUserAsync(User);
           
            await next();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            
            ViewBag.BloodBankOfUser = _user!.BloodBankId;

            var reservations = await _dbContext.Reservations.Include(x => x.ApplicationUser).Include(x => x.BloodBank)
               .Where(x => !x.IsDonate &
               x.DateOnly > DateOnly.FromDateTime(DateTime.Now) &
               x.TimeOnly > TimeOnly.FromDateTime(DateTime.Now)
               ).ToListAsync();
            var mappedReservations = _mapper.Map<IEnumerable<Reservation>, IEnumerable<ReservationViewModel>>(reservations);
            return View(mappedReservations);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Donate(int id)
        {
            var reservation = await _dbContext.Reservations.FindAsync(id);

            if (reservation is null) return BadRequest();

            var user = await _userManager.FindByIdAsync(reservation.ApplicationUserId);
            if (user is null) return BadRequest();

            var donor = await _dbContext.Donors.FirstOrDefaultAsync(x => x.NationalId == user.NationalId);

            if (donor is not null)
            {
                if (donor.DonationDate.AddDays(90) > DateTime.Now)
                {
                    ModelState.AddModelError(nameof(user.BloodTypeId), errorMessage: "60 days must pass since the last donation ");
                    return View("Index");
                }
            }

            var BloodTypes = _bloodTypesServices.GetAllOrdered();
            var viewModel = new DonationFormViewModel()
            {
                Id = id,
                ApplicationUserId = user.Id,
                BloodTypes =_mapper.Map<IEnumerable<SelectListItem>>(BloodTypes),
               BloodTypeId = user.BloodTypeId ?? 0
            };


            return View("Form", viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Donate(DonationFormViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            var user = await _userManager.FindByIdAsync(request.ApplicationUserId);
            if (user is null) return BadRequest();

            if (user.Age < 18 || user.Age > 60)
            {
                ModelState.AddModelError(nameof(request.Quantity), errorMessage: "must be more than 18 and less than 60");
                return View("Index");
            }

            var donor = await _dbContext.Donors.Include(x => x.DonorBanks).FirstOrDefaultAsync(x => x.NationalId == user.NationalId);

            if (donor is not null)
            {
                    if (donor.DonationDate == default & donor.DonationDate.AddDays(90) > DateTime.Now)
                    {
                        ModelState.AddModelError(nameof(request.BloodTypeId), errorMessage: "60 days must pass since the last donation ");
                        return View("Index");
                    }
            }
            else
            {
              var d= _dbContext.Donors.Add(new Donor()
                {
                    Name = user.FullName,
                    Age = user.Age ?? 0,
                    CityId = user.CityId,
                    NationalId = user.NationalId,
                    PhoneNum = user.PhoneNumber,
                    BloodTypeId = request.BloodTypeId,
                    DonationDate = DateTime.Now
                });
               
                _dbContext.SaveChanges();

                donor = await _dbContext.Donors.Include(x=>x.DonorBanks).FirstOrDefaultAsync(x => x.NationalId == user.NationalId);
            }

            if (donor is null) return BadRequest();


            _dbContext.BloodBags.Add(new BloodBag()
            {
                Quantity = request.Quantity,
                BloodTypeId = request.BloodTypeId,
                BloodBankId = _user!.BloodBankId,
                DonorId = donor.Id,

            });
            _dbContext.SaveChanges();


            if (!(donor.DonorBanks.Any(x => x.BloodBankId == _user!.BloodBankId)))
                donor.DonorBanks.Add(new DonorBank { BloodBankId = _user!.BloodBankId });

            _dbContext.Reservations.Where(X=>X.Id == request.Id ).FirstOrDefault()!.IsDonate = true;

            _dbContext.SaveChanges();

            return View("Index");

        }



    }
}
