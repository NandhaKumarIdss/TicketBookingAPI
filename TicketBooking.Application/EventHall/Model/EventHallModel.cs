using System;
using System.Collections.Generic;
using System.Text;

namespace TicketBooking.Application.EventHall.Model
{
    public class EventHallModel
    {
        public Guid Id { get; set; }
        public string HallName { get; set; }
        public bool HallStatus { get; set; }
    }
}
