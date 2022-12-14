using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.Application.EventHall.Model;
using TicketBooking.CrudController;
using TicketBooking.Entities;
using TicketBooking.Repositories.GenericRepository;

namespace TicketBooking.Controllers.HallSeatsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallSeatsController : CrudController<HallSeats>
    {
        public HallSeatsController(IRepository<HallSeats> repository) : base(repository)
        {
        }
    }
}
