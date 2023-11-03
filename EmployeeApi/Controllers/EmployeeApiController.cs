using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeApi.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Post(Employee emp){
            db.Employees.Add(emp);
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
    }
}