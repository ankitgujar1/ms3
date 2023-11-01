using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using p.Models;

namespace p.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        LoginView model=new LoginView();

        if(Request.Cookies["userCookie"]!=null){
            model.Username=Request.Cookies["userCookie"].ToString();

        }
        return View(model);
    }

    [HttpPost]
    public IActionResult Index(LoginView l)
    {
        if(l.Username==l.Password){
            if(l.RememberMe==true){
                CookieOptions o=new CookieOptions();
                o.Expires=DateTime.Now.AddDays(3);
                Response.Cookies.Append("userCookie",l.Username,o);
            }
            return RedirectToAction("Index","Employee");
        }
        else{
            ModelState.AddModelError("","Invalid Creadential");
            return View(l);
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
