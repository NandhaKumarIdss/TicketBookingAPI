using AutoMapper;
using TicketBooking.Application.BookingMaster.Model;

namespace TicketBooking.Application.BookingMaster.Mapping
{
    public class BookingMasterMapping : Profile
    {
        public BookingMasterMapping()
        {
            AllowNullCollections = true;

            CreateMap<TicketBooking.Entities.BookingMaster, BookingMasterModel>().ReverseMap();
        }
    }
}
