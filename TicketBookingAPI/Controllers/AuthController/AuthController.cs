using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TicketBooking.Application.Auth;
using TicketBooking.Application.Auth.AuthModel;
using TicketBooking.Application.Users.Model;
using TicketBooking.Application.Users.Service;
using TicketBooking.Entities;
using TicketBooking.Repositories.GenericRepository;

namespace TicketBooking.Controllers.AuthController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service) 
        {
            _service = service;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthModel model)
        {
            bool isAuthenticated = await _service.AuthenticateUserAsync(model.EmailId, model.Password);

            if (isAuthenticated)
            {
                string token = await _service.GenerateJwtTokenAsync(model.EmailId);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }
}
