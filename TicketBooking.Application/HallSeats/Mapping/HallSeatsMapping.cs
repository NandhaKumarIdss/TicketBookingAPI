using AutoMapper;
using TicketBooking.Application.HallSeats.Model;

namespace TicketBooking.Application.HallSeats.Mapping
{
    public class HallSeatsMapping: Profile
    {
        public HallSeatsMapping()
        {
            AllowNullCollections = true;

            CreateMap<TicketBooking.Entities.HallSeats, HallSeatsModel>().ReverseMap();
        }
    }
}
