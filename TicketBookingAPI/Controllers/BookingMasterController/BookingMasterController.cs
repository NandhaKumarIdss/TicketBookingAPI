using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Application.BookingMaster.Model;
using TicketBooking.CrudController;
using TicketBooking.Entities;
using TicketBooking.Repositories.GenericRepository;

namespace TicketBookingAPI.Controllers.BookingMasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingMasterController : CrudController<BookingMaster,BookingMasterModel>
    {
        public BookingMasterController(IRepository<BookingMaster,BookingMasterModel> repository) : base(repository)
        {
        }
    }
}
