using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcefwithdb.Data
{
    public class Employee
    {
        public int EmployeeId {set;get;}
        public string? EmployeeName {set;get;}
        public int DepartmentId {set;get;}
        public decimal Salary {get;set;}
        public DateTime JoinDate {get;set;}
        // public bool IsRegular {get;set;}

        public virtual Department? Department{get;set;}
    }
}