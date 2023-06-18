using AutoMapper;
using TicketBooking.Application.Mapping;
using TicketBooking.Application.Users.Model;

namespace TicketBooking.Application.Users.Mapping
{
    public class UserMapping : MapProfile
    {
        public UserMapping()
        {
            AllowNullCollections = true;

            CreateMap<TicketBooking.Entities.Users, UserModel>(MemberList.None).
                ReverseMap();
        }
    }
}