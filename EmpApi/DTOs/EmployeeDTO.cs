using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpApi.Models;

namespace EmpApi.DTOs
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
        public decimal Salary { get; set; }
       
        public   DateTime JoinDate { get; set; }
    }
}