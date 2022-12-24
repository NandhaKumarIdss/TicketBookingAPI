using System;
using TicketBooking.Entities.BaseEntity;

namespace TicketBooking.Application.HallSeats.Model
{
    public class HallSeatsModel : Entity
    {
        public string SeatNumber { get; set; }
        public string SeatRow { get; set; }
        public string SeatColumn { get; set; }
        public bool SeatStatus { get; set; }
        public Guid? HallId { get; set; }

    }
}
