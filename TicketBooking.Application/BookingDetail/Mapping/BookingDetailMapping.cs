using AutoMapper;
using TicketBooking.Application.BookingDetail.Model;
using TicketBooking.Application.Mapping;

namespace TicketBooking.Application.BookingDetail.Mapping
{
    public class BookingDetailMapping : MapProfile
    {
        public BookingDetailMapping()
        {
            AllowNullCollections = true;

            CreateMap<TicketBooking.Entities.BookingDetail, BookingDetailModel>(MemberList.None).ReverseMap();
        }
    }
}
