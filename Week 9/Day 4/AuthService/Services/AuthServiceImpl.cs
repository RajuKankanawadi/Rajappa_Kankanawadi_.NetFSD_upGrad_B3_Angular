using AuthService.Data;
using AuthService.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.Services
{
    public class AuthService
    {
        private readonly AuthDbContext _db;
        private readonly IConfiguration _config;

        public AuthService(AuthDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        public User Register(User u)
        {
            _db.Users.Add(u);
            _db.SaveChanges();
            return u;
        }

        public string Login(string email, string password)
        {
            var user = _db.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (user == null) return null;

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "authapi",
                audience: "authapi",
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
