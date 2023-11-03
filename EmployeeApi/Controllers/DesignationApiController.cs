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
    public class DesignationApiController : ControllerBase
    {
        private ApiDbContext db;

        public DesignationApiController(ApiDbContext db){
            this.db=db;
        }

        [HttpGet]
        public IActionResult Get(){
            // var dp=db.Designations;
            return Ok(db.Designations);
        }

        [HttpPost]
        public IActionResult Post(Designation d){
            db.Designations.Add(d);
            db.SaveChanges();
            return Ok();
        }
    }
}