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
    public class DepartmentApiController : ControllerBase
    {
        private ApiDbContext db;

        public DepartmentApiController(ApiDbContext db){
            this.db=db;
        }

        [HttpGet]
        public IActionResult Get(){
            var dp=db.Departments;
            return Ok(dp);
        }

        [HttpPost]
        public IActionResult Post(Department d){
            db.Departments.Add(d);
            db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id){
            var dp=db.Departments.FirstOrDefault(i=>i.DepartmentId==id);
            if(dp!=null){
                
            }
        }
    }
}