using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TicketBooking.Application.Users.Model;
using TicketBooking.Data.TicketBookingDbContext;

namespace TicketBooking.Application.Users.Service
{
    public interface IUserService
    {
        Task<UserModel> GetUserByEmailAsync(string email);
    }
    public class UserService : IUserService
    {
        private readonly TicketBookingDbContext _context;
        private readonly IMapper _mapper;
        public UserService(TicketBookingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserModel> GetUserByEmailAsync(string email)
        {
            var user = await _context.Set<TicketBooking.Entities.Users>().FirstOrDefaultAsync(x => x.EmailId == email);
            if (user != null)
            {
                var userModel = _mapper.Map<UserModel>(user);
                return userModel;
            }

            return null;
        }
    }
}
