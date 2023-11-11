using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpApi.Models;
using EmpApi.DTOs;
 
namespace EmpApi.Repository
{
    public interface IEmployeeRepository
    {
         Employee SearchEmployee(int id);
 
         Employee AddEmployee(Employee emp);
 
         IEnumerable<EmployeeDTO> GetAllEmployees();
 
         Employee DeleteEmployee(int id);
    }
}