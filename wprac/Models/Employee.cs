using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
 
namespace wprac.Models
{
    public class Employee
    {
        public int Id {get;set;}
        public string? Name {get;set;}
        public decimal Salary {get;set;}
        [DataType(DataType.Date)]
        public DateTime JoinDate {get;set;}

        // public int DepartmentId{get;set;}

        // public virtual Department? Department{get;set;}
    }
}