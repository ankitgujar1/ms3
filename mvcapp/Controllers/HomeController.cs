 using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvcapp.Models;
using System.Data.SqlClient;
using System.Data;
using System;
namespace mvcapp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // For normal use
    // public IActionResult Index()
    // {
    //     return View();
    // }


    public ViewResult Index() //for passing the data from controller to view using ViewData
    {
        //ViewData and ViewBag can only rendered once, after that data is lost
        var str="Ankit"; //can have multiple ViewData and ViewBag
        ViewData["name"]=str; //key-value pair
        
        //for passing the data from controller to view using ViewBag
        ViewBag.name2="JJ"; //here no key-val pair, direct assignment
        ViewBag.name3="Simon";

        List<string> list=new List<string>
        {"JJ","W2S","Simon","Ethan","Josh","Vik","Tobi"};
        ViewBag.sidemen=list;

        //for passing the data from controller to view using Model Object
        // we can either send single obj or we can send list/collection of obj
        // Employee e=new Employee{
        //     Id=1,
        //     Name="Ankit",
        //     Salary=50000.50,
        //     JoinDate=DateTime.Parse("16-dec-2019")
        // };

        // return View(e);

        List<Employee> empList=new List<Employee>(){
            new Employee{Id=1,Name="Ankit",Salary=50000.50,JoinDate=DateTime.Parse("16-dec-2019")},
            new Employee{Id=2,Name="Jay",Salary=50000.50,JoinDate=DateTime.Parse("16-dec-2019")},
            new Employee{Id=3,Name="Rahul",Salary=50000.50,JoinDate=DateTime.Parse("16-dec-2019")},
            new Employee{Id=4,Name="Jay",Salary=50000.50,JoinDate=DateTime.Parse("16-dec-2019")},
            new Employee{Id=5,Name="Ankit",Salary=50000.50,JoinDate=DateTime.Parse("16-dec-2019")},
            new Employee{Id=6,Name="Rahul",Salary=50000.50,JoinDate=DateTime.Parse("16-dec-2019")},
        };

        return View(empList);
    }

    
    

    // public IActionResult Privacy()
    // {
    //     return View();
    // }

    // can do this in index() also                      IActionResult vs ViewResult
    public ViewResult Privacy()
    {
        // to print all employees

        List<Employee> empList=new List<Employee>();
        string conStr="server=localhost; database=ltiDB; uid=sa; password=examlyMssql@123";
        SqlConnection con=new SqlConnection(conStr);
        con.Open();
        string q="select * from employees";
        SqlCommand cmd=new SqlCommand(q,con);
        SqlDataReader reader=cmd.ExecuteReader();
        
        while(reader.Read()){
            // Console.WriteLine("{0},{1},{2},{3}",reader.GetInt32(0),reader.GetString(1),reader.GetDecimal(2),reader.GetDateTime(3));
            Employee e=new Employee{
                Id=reader.GetInt32(0),
                Name=reader.GetString(1),
                Salary=(double)reader.GetDecimal(2),
                JoinDate=reader.GetDateTime(3)

            };
            empList.Add(e);

        }
        reader.Close();
        
        con.Close();
        con.Dispose();
        return View(empList);


    }

    public ViewResult Create(){

        string conStr="server=localhost; database=ltiDB; uid=sa; password=examlyMssql@123";
        SqlConnection con=new SqlConnection(conStr);
        con.Open();
        SqlCommand cmd=new SqlCommand("proc_InsertEmp",con);
        cmd.CommandType=CommandType.StoredProcedure;

        //for out parameter
            SqlParameter p_employeeid=new SqlParameter("@employeeid",SqlDbType.Int);
            p_employeeid.Direction=ParameterDirection.Output;
            cmd.Parameters.Add(p_employeeid);

            //for in parameters
            cmd.Parameters.AddWithValue("@employeename","harry");
            cmd.Parameters.AddWithValue("@salary",99999);
            cmd.Parameters.AddWithValue("@joindate","30-nov-2022");

            cmd.ExecuteNonQuery();
            // Console.WriteLine("Row Inserted {0} using Stored Procedure" ,p_employeeid.Value);

            ViewBag.id=p_employeeid.Value;
        return View();
    }

    public IActionResult AboutUs()
    {
        return View();
    }

    public ContentResult Content(){
        return Content("Welcome to ASP.NET MVC");
    }

    public FileResult FileDownload(){
        return File("~/images/peakpx (1).jpg","image/jpg");
    }

    public RedirectResult Redirect(){
        return Redirect("https://getbootstrap.com/docs/4.0/content/images/");
    }

    public JsonResult Json(){
        List<string> l=new List<string>{"JJ","W2S"};
        return Json(l);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
