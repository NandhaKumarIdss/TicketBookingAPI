using System;
using System.Collections.Generic;
using System.Text;
using TicketBooking.Entities.BaseEntity;

namespace TicketBooking.Application.EventHall.Model
{
    public class EventHallModel: Entity
    {
        public string HallName { get; set; }
        public bool HallStatus { get; set; }
    }

  
}
