using AutoMapper;
using TicketBooking.Application.BookingDetail.Model;

namespace TicketBooking.Application.BookingDetail.Mapping
{
    public class BookingDetailMapping : Profile
    {
        public BookingDetailMapping()
        {
            AllowNullCollections = true;

            CreateMap<TicketBooking.Entities.BookingDetail, BookingDetailModel>().ReverseMap();
        }
    }
}
