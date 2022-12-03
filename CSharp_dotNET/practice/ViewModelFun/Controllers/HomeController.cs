using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        string message = "Don't ever, for any reason, do anything, to anyone, for any reason, ever, no matter what, no matter where, or who, or who you are with, or where you are going, or where you've been, ever, for any reason whatsoever. - Michael Scott";
        return View("Index", message);
    }

    [HttpGet("numbers")]
    public IActionResult Numbers()
    {
        int[] NumArray = {1,2,10,21,8,7,3};
        return View("Numbers", NumArray);
    }

    [HttpGet("oneuser")]
    public IActionResult OneUser()
    {
        User newUser = new User()
        {
            FirstName = "Erik",
            LastName = "Mejia"
        };
        return View("OneUser", newUser);
    }

    [HttpGet("users")]
    public IActionResult Users()
    {
        User newUser = new User()
        {
            FirstName = "Erik",
            LastName = "Mejia"
        };
        User newUser2 = new User()
        {
            FirstName = "Nalle",
            LastName = "Easco"
        };
        User newUser3 = new User()
        {
            FirstName = "Jair",
            LastName = "Mejia"
        };
        User newUser4 = new User()
        {
            FirstName = "Naruto",
            LastName = "Uzumaki"
        };
        List<User> ListOfUsers = new List<User>();
        ListOfUsers.Add(newUser);
        ListOfUsers.Add(newUser2);
        ListOfUsers.Add(newUser3);
        ListOfUsers.Add(newUser4);
        return View("Users", ListOfUsers);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
