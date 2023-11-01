using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcefc.Models
{
    public class Employee
    {
        // public int EmployeeId
        public int EmployeeId {set;get;}
        public string? EmployeeName {set;get;}
        public int DepartmentId {set;get;}
        public double Salary {get;set;}
        public DateTime JoinDate {get;set;}
        public bool IsRegular {get;set;}
    }
}