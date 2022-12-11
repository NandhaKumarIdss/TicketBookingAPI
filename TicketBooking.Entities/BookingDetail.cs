using System;


namespace TicketBooking.Entities
{
    public class BookingDetail
    {
        public Guid BookingDetailId { get; set; }
        public int SeatNumber { get; set; }


        public Guid? BookingId { get; set; }
        public virtual BookingMaster BookingMasters { get; set; }

        public Guid? HallSeatId { get; set; }
        public virtual HallSeats HallSeats { get; set; }
    }
}
