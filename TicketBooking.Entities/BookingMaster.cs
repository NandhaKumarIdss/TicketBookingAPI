using System;
using System.Collections.Generic;

namespace TicketBooking.Entities
{
    public class BookingMaster
    {
        public BookingMaster()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public Guid BookingId { get; set; }
        public string CustomerName { get; set; }
        public int NumberOfSeats { get; set; }
        public Guid? HallId { get; set; }

        public virtual EventHall EventHall { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
