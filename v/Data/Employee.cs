using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace v.Data
{
    public class Employee
    {
        public int EmployeeId{get;set;}
        public string? EmployeeName{get;set;}
        public int DId{get;set;}
        public int Salay{get;set;}
        public DateTime JoinDate{get;set;}
        public virtual Department? Department{get;set;}
    }
}