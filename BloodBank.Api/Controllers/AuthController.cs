

using BloodBank.Application.Common.ModelContracts.Auth;
using BloodBank.Application.Services.AuthServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("")]
        [EnableCors("AllowAll")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _authService.GetTokenAsync(request.Email, request.Password);
               return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
        }

        [HttpPost("register")]
        [EnableCors("AllowAll")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _authService.RegisterAsync(request);
            return result.IsSuccess ? Ok() : result.ToProblem();
        }

        [HttpPost("confirm-email")]
        [EnableCors("AllowAll")]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailRequest request)
        {
            var result = await _authService.ConfirmEmailAsync(request);
            return result.IsSuccess ? Ok() : result.ToProblem();
        }

        [HttpPost("resend-confirm-email")]
        [EnableCors("AllowAll")]
        public async Task<IActionResult> ResendConfirmEmail([FromBody] ResendConfirmationEmailRequest request)
        {
            var result = await _authService.ResendConfirmEmailAsync(request);
            return result.IsSuccess ? Ok() : result.ToProblem();
        }

        [HttpPost("forgot-password")]
        [EnableCors("AllowAll")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgetPasswordRequest request)
        {
            var result = await _authService.SendResetPasswordCodeAsync(request);
            return result.IsSuccess ? Ok() : result.ToProblem();
        }

        [HttpPost("reset-password")]
        [EnableCors("AllowAll")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var result = await _authService.ResetPasswordAsync(request);
            return result.IsSuccess ? Ok() : result.ToProblem();
        }
    }
}