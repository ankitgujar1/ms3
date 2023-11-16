using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private IConfiguration _con;



    public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration con)
    {
        _logger = logger;
        _con = con;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpPost]
    [Route("auth")]
    public string AuthenticateUser(UserData data)
    {
        string token = "";
        if(data.Username == "username" & data.Password == "password")
        {
            token = TokenGenerator(data);
        }
        return token;
    }

    [Authorize]
    [HttpPut]
    public string SensitiveResource()
    {
        return "Resource";
    }

    public string TokenGenerator(UserData data)
    {
        //signing keys
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_con["JWT:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //claims
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, data.Username),
            new Claim(ClaimTypes.Role, "hero"),
        };

        var token = new JwtSecurityToken(_con["JWT:Issuer"],
        _con["Audience"], 
        claims, 
        expires: DateTime.Now.AddHours(2), 
        signingCredentials: credentials);

        string finalToken = new JwtSecurityTokenHandler().WriteToken(token);

        return finalToken;
    }
}
