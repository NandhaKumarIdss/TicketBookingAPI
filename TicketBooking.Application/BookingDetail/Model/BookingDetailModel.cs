using System;
using System.Collections.Generic;
using System.Text;

namespace TicketBooking.Application.BookingDetail.Model
{
    public class BookingDetailModel
    {
        public Guid BookingDetailId { get; set; }
        public int SeatNumber { get; set; }
        public Guid? BookingId { get; set; }
        public Guid? HallSeatId { get; set; }
    }
}
