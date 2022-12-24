using AutoMapper;
using TicketBooking.Application.EventHall.Model;
using TicketBooking.Application.Mapping;

namespace TicketBooking.Application.EventHall.Mapping
{
    public class EventHallMapping: MapProfile
    {
        public EventHallMapping()
        {
            AllowNullCollections = true;

            CreateMap<TicketBooking.Entities.EventHall, EventHallModel>(MemberList.None)
                .AfterMap((d, s) => s.HallStatus = false).ReverseMap();
        }
    }
}
