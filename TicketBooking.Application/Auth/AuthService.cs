using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Application.Users.Service;

namespace TicketBooking.Application.Auth
{
    public interface IAuthService
    {
        Task<bool> AuthenticateUserAsync(string email, string password);
        Task<string> GenerateJwtTokenAsync(string email);
        bool VerifyPasswordHash(string password, string passwordHash);
    }
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthService(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        public async Task<bool> AuthenticateUserAsync(string email, string password)
        {
            var user = await _userService.GetUserByEmailAsync(email);

            if (user != null && VerifyPasswordHash(password, user.Password))
            {
                return true;
            }

            return false;
        }



        public async Task<string> GenerateJwtTokenAsync(string email)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key"));
            var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "nandhakumar",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            string encodedToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodedToken;
        }


        public bool VerifyPasswordHash(string password, string passwordHash)
        {
            bool isMatch = BCrypt.Net.BCrypt.Verify(password, passwordHash);
            return isMatch;
        }
    }
}
