using System;
using System.Collections.Generic;
using TicketBooking.Entities.BaseEntity;

namespace TicketBooking.Entities
{
    public class Users: Entity
    {
        public const int MaxPhoneNumber = 20;
        public Users()
        {
            HallSeats = new HashSet<HallSeats>();
            BookingMasters = new HashSet<BookingMaster>();
            BookingDetails = new HashSet<BookingDetail>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }


        public virtual ICollection<EventHall> EventHalls { get; set; }  
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
        public virtual ICollection<HallSeats> HallSeats { get; set; }
        public virtual ICollection<BookingMaster> BookingMasters { get; set; }
    }
}
