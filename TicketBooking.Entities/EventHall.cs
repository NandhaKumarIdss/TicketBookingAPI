using System;
using System.Collections.Generic;

namespace TicketBooking.Entities
{
    public class EventHall
    {
        public EventHall()
        {
            HallSeats = new HashSet<HallSeats>();
            BookingMasters = new HashSet<BookingMaster>();
        }

        public Guid Id { get; set; }
        public string HallName { get; set; }
        public bool HallStatus { get; set; }

        public virtual ICollection<HallSeats> HallSeats { get; set; }
        public virtual ICollection<BookingMaster> BookingMasters { get; set; }
    }
}
