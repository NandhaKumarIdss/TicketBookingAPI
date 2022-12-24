using Microsoft.AspNetCore.Mvc;
using TicketBooking.Application.EventHall.Model;
using TicketBooking.CrudController;
using TicketBooking.Entities;
using TicketBooking.Repositories.GenericRepository;

namespace TicketBookingAPI.Controllers.EventHallController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventHallController : CrudController<EventHall,EventHallModel>
    {
        public EventHallController(IRepository<EventHall,EventHallModel> repository) : base(repository)
        {
        }
    }
}
