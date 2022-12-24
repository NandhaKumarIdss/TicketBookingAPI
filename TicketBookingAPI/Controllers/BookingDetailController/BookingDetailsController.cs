using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.Application.BookingDetail.Model;
using TicketBooking.CrudController;
using TicketBooking.Entities;
using TicketBooking.Repositories.GenericRepository;

namespace TicketBooking.Controllers.BookingDetailController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingDetailsController : CrudController<BookingDetail,BookingDetailModel>
    {
        public BookingDetailsController(IRepository<BookingDetail,BookingDetailModel> repository) : base(repository)
        {
        }
    }
}
