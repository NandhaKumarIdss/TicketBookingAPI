using System;
using System.Collections.Generic;
using System.Text;
using TicketBooking.Entities.BaseEntity;

namespace TicketBooking.Application.BookingMaster.Model
{
    public class BookingMasterModel : Entity
    {
        public string CustomerName { get; set; }
        public int NumberOfSeats { get; set; }
        public Guid? HallId { get; set; }
    }
}
