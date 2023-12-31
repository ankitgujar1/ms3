using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApi.Models
{
    public class Employee
    {
        public int EmployeeId{get;set;}
        public string? EmployeeName{get;set;}
        public double Salary{get;set;}

        public int DepartmentId{get;set;}
        public int DesignationId{get;set;}

        public virtual Department? Department{get;set;}

        public virtual Designation? Designation{get;set;}

    }
}