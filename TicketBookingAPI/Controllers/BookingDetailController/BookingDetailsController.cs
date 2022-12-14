using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.CrudController;
using TicketBooking.Entities;
using TicketBooking.Repositories.GenericRepository;

namespace TicketBooking.Controllers.BookingDetailController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingDetailsController : CrudController<BookingDetail>
    {
        public BookingDetailsController(IRepository<BookingDetail> repository) : base(repository)
        {
        }
    }
}
