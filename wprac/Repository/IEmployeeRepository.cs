using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wprac.Models;
 
namespace wprac.Repository
{
    public interface IEmployeeRepository
    {
        ICollection<Employee> GetAllEmployee();
        void AddEmployee(Employee e);
        Employee FindById(int id);
        void DeleteEmployee(int id);
        void EditEmployee (Employee e);
 
    }
}