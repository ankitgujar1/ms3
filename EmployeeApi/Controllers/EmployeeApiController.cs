using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EmployeeApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
// using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeApiController : ControllerBase
    {
    
        private ApiDbContext db;

        public EmployeeApiController(ApiDbContext db){
            this.db=db;
        }

        [HttpGet]
        public IActionResult Get(){
            var e=db.Employees;
            return Ok(e);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id){
            var e=db.Employees.FirstOrDefault(i=>i.EmployeeId==id);
            if(e!=null) return Ok(e);
            else return NotFound();
        }

        [HttpPost]
        public IActionResult Post(Employee e)
        {
            db.Employees.Add(e);
            db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id){
            var dp=db.Employees.FirstOrDefault(i=>i.EmployeeId==id);
            if(dp!=null){
               db.Employees.Remove(dp); 
               db.SaveChanges();
               return Ok();
            } 
            else return NotFound();
        }

        [HttpPut]
        public IActionResult Put(int id,Employee e){
               db.Update(e); 
               db.SaveChanges();
               return Ok();
        }

        //route - no need to specify action name url in case of api
        [HttpGet]
        [Route("user/{uname}/{pword}")]
        public string ValidateUser(string uname,string pword){
            if(uname==pword) return "Valid User";
            return "Not Valid";
        }

        [HttpGet]
        [Route("admin/{uname}/{pword}")]
        public string ValidateAdmin(string uname,string pword){
            if(uname==pword) return "Valid User";
            return "Not Valid";
        }

        [HttpGet]
        [Route("add/{n}/{m}")]
        public int Add(int n,int m){
            return n+m;
        }

        [HttpPost]
        [Route("auth")]
        public string AuthenticateEmployee(User data)
        {
            string token = "";
            if(data.Username == "username" && data.Password == "password")
            {
                token = TokenGenerator(data);
            }
            return token;
        }
 
        public string TokenGenerator(User data)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_con["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey , SecurityAlgorithms.HmacSha256);
 
            var claims = new[]
            {
                new Claim(ClaimTypes.Name , data.Username),
                new Claim(ClaimTypes.Role , "hero"),
                // new Claim(ClaimTypes.Role , "Admin")
 
            };
 
            var token = new JwtSecurityToken(_con["JWT:Issuer"] ,
            _con["JWT:Audience"] ,
            claims ,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: credentials
            );
 
            string finalToken = new JwtSecurityTokenHandler().WriteToken(token);
 
            return finalToken;
        }
 
    }
}