using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Application.BookingMaster.Model;
using TicketBooking.Application.BookingMaster.Service;
using TicketBooking.CrudController;
using TicketBooking.Entities;
using TicketBooking.Repositories.GenericRepository;

namespace TicketBookingAPI.Controllers.BookingMasterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingMasterController : CrudController<BookingMaster,BookingMasterModel>
    {
        private readonly IBookingMasterService _service;
        public BookingMasterController(IRepository<BookingMaster,BookingMasterModel> repository, IBookingMasterService service) : base(repository)
        {
            _service = service;
        }
    }
}
