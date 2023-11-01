// namespace EmployeeDetails;
namespace  DisconnectedAdo;
using System;

class Program{
    static void Main(string[] args){
    EmployeeDetails ed=new EmployeeDetails();

    Employees e=new Employees{
        Name="KSI",
        Salary=90000,
        JoinDate=DateTime.Parse("12-dec-2022")
    };

    // ed.AddEmp(e);
    ed.GetAllEmployees();

    // ed.SearchEmp(10);

    // ed.DeleteEmp(8);

    // ed.UpdateEmp(10,e);

    // ed.DisplayStates();


    }
}