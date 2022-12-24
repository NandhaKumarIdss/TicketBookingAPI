using AutoMapper;
using TicketBooking.Application.HallSeats.Model;
using TicketBooking.Application.Mapping;

namespace TicketBooking.Application.HallSeats.Mapping
{
    public class HallSeatsMapping: MapProfile
    {
        public HallSeatsMapping()
        {
            AllowNullCollections = true;

            CreateMap<TicketBooking.Entities.HallSeats, HallSeatsModel>(MemberList.None)
                .AfterMap((d, s) => s.SeatStatus = true).ReverseMap();
        }
    }
}
