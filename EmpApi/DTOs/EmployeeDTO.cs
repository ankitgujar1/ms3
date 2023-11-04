using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpApi.Models;

namespace EmpApi.DTOs
{
    public class EmployeeDTO
    {
        public int EmployeeId{get;set;}
        public string? EmployeeName{get;set;}
        public double Salary{get;set;}

        public string DepartmentName{get;set;}
        // public int DesignationId{get;set;}

        // public virtual Department? Department{get;set;}
    }
}