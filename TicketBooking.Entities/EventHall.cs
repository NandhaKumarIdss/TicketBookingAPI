using System;
using System.Collections.Generic;
using TicketBooking.Entities.BaseEntity;

namespace TicketBooking.Entities
{
    public class EventHall: Entity
    {
        public EventHall()
        {
            HallSeats = new HashSet<HallSeats>();
            BookingMasters = new HashSet<BookingMaster>();
        }

        public string HallName { get; set; }
        public bool HallStatus { get; set; }

        public virtual ICollection<HallSeats> HallSeats { get; set; }
        public virtual ICollection<BookingMaster> BookingMasters { get; set; }
    }
}
