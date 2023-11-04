using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpApi.Models;
using EmpApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EmpApi.Repository
{
    public class EmployeeRepository
    {
        private EmpApiDbContext db;

        public EmployeeRepository(){
            
        }

        public EmployeeRepository(EmpApiDbContext db){
            this.db=db;
        }

        public Employee AddEmp(Employee e){
            db.Employees.Add(e);
            db.SaveChanges();
            return e;
        }

        public Employee FindEmp(int id){
            var e=db.Employees.Find(id);
            if(e!=null) return e;
            return null;
        }

        public Employee DeleteEmp(int id){
            var e=db.Employees.Find(id);
            if(e!=null){
                db.Employees.Remove(e);
                db.SaveChanges();
                return e;
            }
            return null;
        }

        public Employee UpdateEmp(int id){
            var e=db.Employees.Find(id);
            if(e!=null){
                db.Update(e);
                db.SaveChanges();
                return e;
            }
            return null;
        }

        public List<EmployeeDTO> GetAllEmp(){
            var empList=db.Employees.Include("Department")
            .Select(e=>new EmployeeDTO{
                EmployeeId=e.EmployeeId,
                EmployeeName=e.EmployeeName,
                DepartmentName=e.Department.DepartmentName,
                Salary=e.Salary
                // JoinDate=e.JoinDate
            }).ToList();

            return empList;
        }
    }
}