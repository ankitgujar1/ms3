using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpApi.Models;
using EmpApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EmpApi.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmpApiDbContext db;
 
        public EmployeeRepository()
        {
 
        }
       
        public EmployeeRepository(EmpApiDbContext db)
        {
            this.db=db;
        }
 
 
        public Employee AddEmployee(Employee emp)
        {
            db.Employees.Add(emp);
            db.SaveChanges();
            return (emp);
        }
 
        public Employee SearchEmployee(int id)
        {
            var emp = db.Employees.FirstOrDefault(e=>e.EmployeeId == id);
            if(emp!=null)
                return (emp);
            else
                return null;
        }
 
        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            var empList = db.Employees.Include("Department")
                .Select(e => new EmployeeDTO{
                   EmployeeId =  e.EmployeeId,
                   EmployeeName = e.EmployeeName,
                    DepartmentName = e.Department.DepartmentName,
                    Salary = (decimal)e.Salary,
                    // JoinDate =  e.JoinDate
                }).ToList();
 
            return empList;
        }
 
        public Employee DeleteEmployee(int id)
        {
            var emp= db.Employees.Find(id);
            if(emp!=null)
            {
                db.Employees.Remove(emp);
                db.SaveChanges();
                return emp;
            }
            else
            {
                return null;
            }
        }
 
        public Employee UpdateEmployee(int id , Employee newemp)
        {
            var emp = db.Employees.Find(id);
            if(emp!=null)
            {
                db.Update(newemp);
                db.SaveChanges();
                return emp;
            }
            else
            {
                return null;
            }
        }
 
    }
}