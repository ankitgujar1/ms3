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
    public class DesignationApiController : ControllerBase
    {
        private ApiDbContext db;

        public DesignationApiController(ApiDbContext db){
            this.db=db;
        }

        [HttpGet]
        public IActionResult Get(){
            var dp=db.Designations;
            return Ok(dp);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id){
            var dp=db.Designations.FirstOrDefault(i=>i.DesignationId==id);
            if(dp!=null){
               return Ok(dp);
            } 
            else return NotFound();
        }

        [HttpPost]
        public IActionResult Post(Designation d){
            db.Designations.Add(d);
            db.SaveChanges();
            return Created("Get",d);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id){
            var dp=db.Designations.FirstOrDefault(i=>i.DesignationId==id);
            if(dp!=null){
               db.Designations.Remove(dp); 
               db.SaveChanges();
               return Ok();
            } 
            else return NotFound();
        }

        [HttpPut]
        // [Route("{id}")]
        public IActionResult Put(int id,Designation d){
            var ds=db.Designations.Find(id);
            if(ds!=null){
               db.Update(d); 
               db.SaveChanges();
               return Ok();
            }
            else return NotFound();
        }

        
    }
}