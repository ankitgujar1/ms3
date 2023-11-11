using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpApi.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public decimal Salary { get; set; }
       
        public int DepartmentId { get; set; }
        // public   DateTime JoinDate { get; set; }
        public virtual Department Department {set; get;}
    }
}