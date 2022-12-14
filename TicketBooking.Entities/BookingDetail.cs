using System;
using TicketBooking.Entities.BaseEntity;

namespace TicketBooking.Entities
{
    public class BookingDetail: Entity
    {
        public int SeatNumber { get; set; }
        public Guid? BookingId { get; set; }
        public Guid? HallSeatId { get; set; }

        public virtual BookingMaster BookingMasters { get; set; }
        public virtual HallSeats HallSeats { get; set; }
    }
}
