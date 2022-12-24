using AutoMapper;
using TicketBooking.Application.BookingMaster.Model;
using TicketBooking.Application.Mapping;

namespace TicketBooking.Application.BookingMaster.Mapping
{
    public class BookingMasterMapping : MapProfile
    {
        public BookingMasterMapping()
        {
            AllowNullCollections = true;

            CreateMap<TicketBooking.Entities.BookingMaster, BookingMasterModel>(MemberList.None).ReverseMap();
        }
    }
}
