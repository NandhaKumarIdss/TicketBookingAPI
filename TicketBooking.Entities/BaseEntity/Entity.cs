using System;
using System.Collections.Generic;
using System.Text;

namespace TicketBooking.Entities.BaseEntity
{
    public class Entity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
