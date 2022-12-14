using AutoMapper;
using TicketBooking.Application.EventHall.Model;

namespace TicketBooking.Application.EventHall.Mapping
{
    public class EventHallMapping: Profile
    {
        public EventHallMapping()
        {
            AllowNullCollections = true;

            CreateMap<TicketBooking.Entities.EventHall, EventHallModel>().ReverseMap();
        }
    }
}
