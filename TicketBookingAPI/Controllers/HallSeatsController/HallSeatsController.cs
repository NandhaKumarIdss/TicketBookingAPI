using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.Application.HallSeats.Model;
using TicketBooking.Application.HallSeats.Service;
using TicketBooking.CrudController;
using TicketBooking.Entities;
using TicketBooking.Repositories.GenericRepository;

namespace TicketBooking.Controllers.HallSeatsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallSeatsController : CrudController<HallSeats, HallSeatsModel>
    {
        private readonly IHallSeatsService _service;
        public HallSeatsController(IRepository<HallSeats, HallSeatsModel> repository, IHallSeatsService service) : base(repository)
        {
            _service = service;
        }
    }
}
