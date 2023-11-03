using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            // var dp=db.Departments;
            return Ok(db.Departments);
        }

        [HttpPost]
        public IActionResult Post(Department d){
            db.Departments.Add(d);
            db.SaveChanges();
            return Ok();
        }
    }
}