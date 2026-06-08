using BloodBank.Application.Common.ModelContracts.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Services.Reservation
{
    public interface IReservationService
    {
          Task<Result> BookAppointment(string userId , ReservationRequest reservationRequest);

    }
}
