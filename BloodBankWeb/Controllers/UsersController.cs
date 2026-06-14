using BloodBank.Application.Services.AuthServices;
using BloodBank.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

namespace BloodBankWeb.Controllers
{
    [Authorize(Roles = AppRoles.Admin)]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsersController(UserManager<ApplicationUser> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager, IUnitOfWork unitOfWork )
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.Include(u => u.BloodType).ToListAsync();

            var userRoles = new Dictionary<string, bool>();

            foreach (var user in users)
            {
                userRoles[user.Id] = await _userManager.IsInRoleAsync(user, "Admin");
            }

            ViewBag.UserRoles = userRoles;


            var viewModel = _mapper.Map<IEnumerable<UserViewModel>>(users);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var viewModel = new UserFormViewModel
            {
                Roles = await _roleManager.Roles.Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                }).ToListAsync()
                //,BloodTypes = _context.BloodTypes.Select(b=>new SelectListItem
                //{
                //    Text=b.Name,
                //    Value = b.Id 
                //}).ToListAs()
                ,
                BloodTypes = _mapper.Map<IEnumerable<SelectListItem>>(_unitOfWork.BloodTypes.GetAll()),

                Cites = _mapper.Map<IEnumerable<SelectListItem>>(_unitOfWork.Cites.GetAll())

                ,Banks = _mapper.Map<IEnumerable<SelectListItem>>(_unitOfWork.BloodBanks.GetAll())
            };


            return View("Form", viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            var existNationalId = _userManager.Users.FirstOrDefault(u => u.NationalId == model.NationalId);


            ApplicationUser user = new()
            {
                FullName = model.FullName,
                UserName = model.UserName,
                Email = model.Email,
                NationalId = model.NationalId,
                BloodType = _unitOfWork.BloodTypes.Find(b => b.Id == model.SelectedBloodType)
                ,EmailConfirmed=true,
                PhoneNumber = model.PhoneNumber,
                CityId = model.CityId,
                BloodBankId =model.BloodBankId,
                Age = ParseIdAndCalculateAge(model.NationalId).age
            };


            var result = await _userManager.CreateAsync(user, model.Password!);

            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, model.SelectedRoles);

                return RedirectToAction(nameof(Index));
            }

            return BadRequest();

        }

        [HttpGet]
        public async Task<IActionResult> ResetPassword(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);

            if (user is null) return NotFound();

            var viewModel = new ResetPasswordFormViewModel { Id = user.Id };

            return View("ResetPasswordForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordFormViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await _userManager.FindByIdAsync(model.Id);

            if (user is null)
                return NotFound();

            var currentPasswordHash = user.PasswordHash;

            await _userManager.RemovePasswordAsync(user);

            var Result = await _userManager.AddPasswordAsync(user, model.Password);

            if (Result.Succeeded)
            {
                await _userManager.UpdateAsync(user);
                return RedirectToAction(nameof(Index));
            }

            user.PasswordHash = currentPasswordHash;
            await _userManager.UpdateAsync(user);

            return BadRequest(string.Join(',', Result.Errors.Select(r => r.Description)));


        }


        [HttpGet]
        public async Task<IActionResult> Edit(string Id)
        {
            var user = await _userManager.Users.Include(u => u.BloodType).FirstOrDefaultAsync(u => u.Id == Id); ;

            if (user is null)
                return NotFound();

            var viewModel = _mapper.Map<UserFormViewModel>(user);

            viewModel.SelectedRoles = await _userManager.GetRolesAsync(user);
            viewModel.Roles = await _roleManager.Roles
                                                .Select(r => new SelectListItem
                                                {
                                                    Text = r.Name,
                                                    Value = r.Name
                                                }).ToListAsync();

            viewModel.SelectedBloodType = user.BloodType?.Id;

            var types = _unitOfWork.BloodTypes.GetAll();

            viewModel.BloodTypes = _mapper.Map<IEnumerable<SelectListItem>>(types);

            viewModel.Cites = _mapper.Map<IEnumerable<SelectListItem>>(_unitOfWork.Cites.GetAll());

            viewModel.Banks = _mapper.Map<IEnumerable<SelectListItem>>(_unitOfWork.BloodBanks.GetAll());

            return View("Form", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserFormViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await _userManager.Users/*.Include(u=>u.BloodType)*/.FirstOrDefaultAsync(u => u.Id == model.Id);

            if (user is null)
                return NotFound();

            var bloodtypeId = user.BloodTypeId;

            user = _mapper.Map(model, user);
            user.NormalizedEmail = model.Email.ToUpper();
            user.NormalizedUserName = model.UserName.ToUpper();
            user.CityId = model.CityId;
            user.BloodBankId = model.BloodBankId;

            if (model.SelectedBloodType.HasValue)
                {
                    // Validate that the new BloodType is exists
                    var newBloodType =  _unitOfWork.BloodTypes.Find(b=> b.Id == model.SelectedBloodType.Value);

                    if (newBloodType == null)
                        return BadRequest("Invalid BloodType selected.");

                    user.BloodTypeId = model.SelectedBloodType.Value;
                }
                else
                {

                    user.BloodTypeId = bloodtypeId;
                }
           

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                var currentRoles = await _userManager.GetRolesAsync(user);

                var rolesUpdated = !currentRoles.SequenceEqual(model.SelectedRoles);

                if (rolesUpdated)
                {
                    await _userManager.RemoveFromRolesAsync(user, currentRoles);
                    await _userManager.AddToRolesAsync(user, model.SelectedRoles);
                }

                return RedirectToAction(nameof(Index));

            }

            return BadRequest(string.Join(',', result.Errors.Select(e => e.Description)));

        }



        //Delete User 


        [HttpPost]
        public async Task<IActionResult> Delete(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return BadRequest();

          

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == Id);
            if (user == null)
                return NotFound();

            var currentUserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            var isUserAdmin = _userManager.IsInRoleAsync(user, "Admin").Result;

            if (user.Id == currentUserId || isUserAdmin)
            {
                throw new InvalidOperationException("You cannot delete your own account.");
            }

          
            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
                return RedirectToAction(nameof(Index));


            return BadRequest(string.Join(", ", result.Errors.Select(e => e.Description)));
        }



        public async Task<IActionResult> CheckNationalId(UserFormViewModel model)
        {
            var user = model.Id is null ? await _userManager.Users.FirstOrDefaultAsync(u => u.NationalId == model.NationalId)
                : await _userManager.Users.Where(u => u.Id != model.Id).FirstOrDefaultAsync(u => u.NationalId == model.NationalId);


            var isExist = user is null;
            return Json(isExist);
        }

        public async Task<IActionResult> AllowEmails(UserFormViewModel model)
        {
            var user = model.Id is null ?
                await _userManager.FindByEmailAsync(model.Email) :
                await _userManager.Users.Where(u => u.Id != model.Id).FirstOrDefaultAsync(u => u.Email == model.Email);

            //await _userManager.FindByEmailAsync(model.Email);
            var isExist = user is null;
            return Json(isExist);
        }




        public static (DateTime dob, int age) ParseIdAndCalculateAge(string id)
        {

            char centuryDigit = id[0];
            string yearPart = id.Substring(1, 2);
            string monthPart = id.Substring(3, 2);
            string dayPart = id.Substring(5, 2);

            // Determine century
            int century = centuryDigit == '3' ? 2000 : 1900;
            int year = century + int.Parse(yearPart);
            int month = int.Parse(monthPart);
            int day = int.Parse(dayPart);

            // Create DateTime object
            DateTime dob;
            try
            {
                dob = new DateTime(year, month, day);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentException("Invalid NationalId");
            }

            // Calculate age
            int age = CalculateAge(dob, DateTime.Today);

            return (dob, age);
        }

        private static int CalculateAge(DateTime birthDate, DateTime referenceDate)
        {
            int age = referenceDate.Year - birthDate.Year;
            if (referenceDate.Month < birthDate.Month ||
                (referenceDate.Month == birthDate.Month && referenceDate.Day < birthDate.Day))
            {
                age--;
            }
            return age;
        }

    }
}
