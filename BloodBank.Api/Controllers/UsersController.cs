using BloodBank.Application.Common.ModelContracts.Auth;
using BloodBank.Application.Common.ModelContracts.Users;
using BloodBank.Application.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BloodBank.Api.Controllers
{
    [Route("me")]
    [ApiController]
    [Authorize]
    public class UsersController(IUserService userService ,ApplicationDbContext context) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly ApplicationDbContext _context = context;



        [HttpGet("")]
        public async Task<IActionResult> Info()
        {
            var result =await _userService.GetProfileAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

           return Ok(result.Value);

        } 

        [HttpPut("Info")]
        public async Task<IActionResult> Info([FromBody] UpdateProfileRequest request)
        {
            var BloodTypeId = await _context.BloodTypes.Where(x=>x.Id == request.BloodTypeId).SingleOrDefaultAsync();

            if (BloodTypeId is null)
            { 
            return Result.Failure<AuthResponse>(UserErrors.NotAllowedBloodType).ToProblem();
            }

           await _userService.UpdateProfileAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)! , request);

           return NoContent();

        }

        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
          var result =  await _userService.ChangePasswordAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)! , request);


           return result.IsSuccess ? NoContent() : result.ToProblem();

        }

    }
}
