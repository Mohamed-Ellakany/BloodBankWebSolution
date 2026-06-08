using BloodBank.Application.Common.ModelContracts.Reservation;
using BloodBank.Application.Services.Reservation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BloodBank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReservationsController(IReservationService reservationService) : ControllerBase
    {
        private readonly IReservationService _reservationService = reservationService;

        [HttpPost]
        public async Task<ActionResult> AddDonateReservation(ReservationRequest reservation)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var result = await _reservationService.BookAppointment(userId,reservation);

            return result.IsSuccess? Ok() : result.ToProblem();

        }
    
    
    }
}
