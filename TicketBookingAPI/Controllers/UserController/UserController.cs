using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.Application.Users.Model;
using TicketBooking.Application.Users.Service;
using TicketBooking.CrudController;
using TicketBooking.Entities;
using TicketBooking.Repositories.GenericRepository;

namespace TicketBooking.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CrudController<Users, UserModel>
    {
        private readonly IUserService _service;
        public UserController(IRepository<Users, UserModel> repository, IUserService service) : base(repository)
        {
            _service = service; 
        }
    }
}
