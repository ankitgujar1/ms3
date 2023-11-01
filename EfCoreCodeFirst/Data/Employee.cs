using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreCodeFirst.Data;
    public class Employee
    {
        public int EmployeeId{get;set;}
        public string? EmployeeName{set;get;}
        public int DepartmentId{get;set;}
        public double Salary{get;set;}
        public DateTime JoinDate{get;set;}

        public virtual Department? Department{get;set;}
    }