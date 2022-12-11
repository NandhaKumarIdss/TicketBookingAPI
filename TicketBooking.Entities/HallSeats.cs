using System;
using System.Collections.Generic;


namespace TicketBooking.Entities
{
    public class HallSeats
    {
        public HallSeats()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public Guid Id { get; set; }
        public string SeatNumber { get; set; }
        public string SeatRow { get; set; }
        public string SeatColumn { get; set; }
        public bool SeatStatus { get; set; }

        public Guid? HallId { get; set; }
        public virtual EventHall EventHall { get; set; }

        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
