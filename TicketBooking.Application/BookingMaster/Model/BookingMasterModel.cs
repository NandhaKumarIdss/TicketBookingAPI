using System;
using System.Collections.Generic;
using System.Text;

namespace TicketBooking.Application.BookingMaster.Model
{
    public class BookingMasterModel
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public int NumberOfSeats { get; set; }
        public Guid? HallId { get; set; }
    }
}
