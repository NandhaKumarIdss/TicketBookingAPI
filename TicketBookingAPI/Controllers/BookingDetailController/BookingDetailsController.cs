using Microsoft.AspNetCore.Mvc;
using TicketBooking.Application.BookingDetail.Model;
using TicketBooking.Application.BookingDetail.Service;
using TicketBooking.CrudController;
using TicketBooking.Entities;
using TicketBooking.Repositories.GenericRepository;

namespace TicketBooking.Controllers.BookingDetailController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingDetailsController : CrudController<BookingDetail,BookingDetailModel>
    {
        private readonly IBookingDetailService _service; 
        public BookingDetailsController(IRepository<BookingDetail,BookingDetailModel> repository, IBookingDetailService service) : base(repository)
        {
            _service = service;
        }
    }
}
