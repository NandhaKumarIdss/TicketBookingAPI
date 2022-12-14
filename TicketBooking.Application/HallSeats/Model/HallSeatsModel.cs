using System;

namespace TicketBooking.Application.HallSeats.Model
{
    public class HallSeatsModel
    {
        public Guid Id { get; set; }
        public string SeatNumber { get; set; }
        public string SeatRow { get; set; }
        public string SeatColumn { get; set; }
        public bool SeatStatus { get; set; }
        public Guid? HallId { get; set; }

    }
}
