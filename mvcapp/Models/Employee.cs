using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcapp.Models
{
    public class Employee
    {
        public int Id{set;get;}
        public string? Name{get;set;}
        public double Salary{get;set;}
        public DateTime JoinDate{get;set;}
    }
}