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

        private List<Employee> l=new List<Employee>{
            new Employee{EmployeeId}
        };
        public IEnumerable<Employee> Get(){

        }
    }
}