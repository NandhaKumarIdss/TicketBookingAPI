using System;
using System.Collections.Generic;
using TicketBooking.Entities.BaseEntity;

namespace TicketBooking.Entities
{
    public class BookingMaster: Entity
    {
        public BookingMaster()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public string CustomerName { get; set; }
        public int NumberOfSeats { get; set; }

        public Guid? HallId { get; set; }
        public virtual EventHall EventHall { get; set; }

        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
