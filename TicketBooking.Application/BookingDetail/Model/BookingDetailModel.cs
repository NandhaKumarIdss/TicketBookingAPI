using System;
using TicketBooking.Entities.BaseEntity;

namespace TicketBooking.Application.BookingDetail.Model
{
    public class BookingDetailModel: Entity
    {
        public int SeatNumber { get; set; }
        public Guid? BookingId { get; set; }
        public Guid? HallSeatId { get; set; }
    }
}
