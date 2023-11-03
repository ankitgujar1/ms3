using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Models;

namespace EmployeeApi.Controllers
{

   
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {

        //methods name can only be Get, Post, 
         private static List<Employee> l = new List<Employee>{
            new Employee{EmployeeId=1,EmployeeName="ankit",Salary=234},
            new Employee{EmployeeId=2,EmployeeName="mustafa",Salary=98765},
            new Employee{EmployeeId=3,EmployeeName="pooja",Salary=5678},
            new Employee{EmployeeId=4,EmployeeName="kimaya",Salary=7632}

        };

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return l;
        }

        [HttpGet]
        [Route("{id}")]
        public Employee Get(int id){
            var e=l.FirstOrDefault(i=>i.EmployeeId==id);
            return e;
        }


        [HttpPost]
        public void Post(Employee e){
            l.Add(e);
        }
    }
}