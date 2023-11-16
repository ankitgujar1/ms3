using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApi.Models
{
    public interface IJWTManagerRepository
    {
        string Authenticate(Users users);
    }
    public class Users
    {
        public string Name { get; set; }
        public string Password { get; set; }

        internal bool Any(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
    public class Tokens
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }

    public class JWTManagerRepository : IJWTManagerRepository
    {
        Dictionary<string, string> users = new Dictionary<string, string>()
        {
            {"user1","password1" },
             {"user2","password2" }
        };

        private readonly IConfiguration configuration;

        public JWTManagerRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public string Authenticate(Users user)
        {
            if (!users.Any(x => x.Key == user.Name && x.Value == user.Password))
            {
                return null;
            }


     var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
        new Claim("Name", user.Name),
        new Claim(ClaimTypes.Role,"User"),
        new Claim(ClaimTypes.Role,"FreshUser"),
        new Claim(ClaimTypes.UserData, "Ram")
       
    };

            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

       
    }

}