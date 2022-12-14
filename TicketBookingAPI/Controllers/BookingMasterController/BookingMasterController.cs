using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.CrudController;
using TicketBooking.Entities;
using TicketBooking.Repositories.GenericRepository;

namespace TicketBookingAPI.Controllers.BookingMasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingMasterController : CrudController<BookingMaster>
    {
        public BookingMasterController(IRepository<BookingMaster> repository) : base(repository)
        {
        }
    }
}
