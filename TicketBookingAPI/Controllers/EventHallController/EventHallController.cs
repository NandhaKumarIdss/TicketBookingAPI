using Microsoft.AspNetCore.Mvc;
using TicketBooking.Application.EventHall.Model;
using TicketBooking.Application.EventHall.Service;
using TicketBooking.CrudController;
using TicketBooking.Entities;
using TicketBooking.Repositories.GenericRepository;

namespace TicketBookingAPI.Controllers.EventHallController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventHallController : CrudController<EventHall,EventHallModel>
    {
        private readonly IEventHallService _service;
        public EventHallController(IRepository<EventHall,EventHallModel> repository, IEventHallService service) : base(repository)
        {
            _service = service;
        }
    }
}
