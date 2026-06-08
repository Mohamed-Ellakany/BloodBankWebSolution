using BloodBank.Application.Common.ModelContracts.Reservation;
using BloodBank.Domain.Consts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBank.Application.Services.Reservation
{
    public class ReservationService(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager) : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager = userManager;

        public async Task<Result> BookAppointment(string userId, ReservationRequest reservationRequest)
        {
            // 1. User validation
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                return Result.Failure(new Error("UserNotDefined", "User not found", StatusCodes.Status401Unauthorized));

            if (user.Age < 18 || user.Age > 60)
                return Result.Failure(new Error("Age", "Age must be between 18 and 60", StatusCodes.Status400BadRequest));



            // 2. Donation eligibility check
            var donor = _unitOfWork.Donors.Find(x => x.NationalId == user.NationalId);
            if (donor != null && (DateTime.UtcNow - donor.DonationDate).TotalDays < 90)
                return Result.Failure(UserErrors.LastDonationTime);



            // 3. Time validation
            var requestedDateTime = reservationRequest.DateOnly.ToDateTime(reservationRequest.TimeOnly);
            if (requestedDateTime < DateTime.UtcNow)
                return Result.Failure(new Error("PastBooking",
                    "Cannot book appointments in the past",
                    StatusCodes.Status400BadRequest));



            // 4. Check daily booking limit (max 3 per day)
            var dailyBookings = _unitOfWork.Reservations.GetAll()
                .Count(x => x.ApplicationUserId == userId &&
                           x.DateOnly == reservationRequest.DateOnly);


            if (dailyBookings >= 3)
                return Result.Failure(new Error("DailyLimit",
                    "Maximum 3 bookings per day allowed",
                    StatusCodes.Status400BadRequest));



            // 5. Check 15-minute buffer (ONLY for same day)
            var sameDayReservations = _unitOfWork.Reservations.GetAll()
                .Where(x => x.ApplicationUserId == userId &&
                           x.DateOnly == reservationRequest.DateOnly)
                .ToList();


            if (_unitOfWork.BloodBanks.Find(x=>x.Id == reservationRequest.BloodBankId) is null )
            {
                return Result.Failure(new Error("This is not our bank",
                        $"Please enter avaliable bank",
                        StatusCodes.Status400BadRequest));
            }



            foreach (var existing in sameDayReservations)
            {
                var existingTime = existing.DateOnly.ToDateTime(existing.TimeOnly);
                if (Math.Abs((requestedDateTime - existingTime).TotalMinutes) < 15)
                {
                    return Result.Failure(new Error("TimeBufferConflict",
                        $"Please keep 15 minutes between appointments on the same day. Conflicts with {existing.TimeOnly}",
                        StatusCodes.Status409Conflict));
                }
            }

            // 6. Create reservation
            _unitOfWork.Reservations.Add(new Domain.Entities.Reservation
            {
                ApplicationUserId = userId,
                DateOnly = reservationRequest.DateOnly,
                TimeOnly = reservationRequest.TimeOnly,
                BloodBankId = reservationRequest.BloodBankId,
                IsDonate = false
            });

            try
            {
                var result = _unitOfWork.Complete();
                return result > 0
                    ? Result.Success()
                    : Result.Failure(new Error("SaveError", "Failed to save", StatusCodes.Status500InternalServerError));
            }
            catch (Exception ex)
            {
                return Result.Failure(new Error("SystemError", ex.Message, StatusCodes.Status500InternalServerError));
            }
        }
    }
}