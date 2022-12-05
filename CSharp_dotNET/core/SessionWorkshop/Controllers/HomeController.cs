using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionWorkshop.Models;

namespace SessionWorkshop.Controllers;

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
        return View("Index");
    }

    [HttpPost("login")]
    public IActionResult Login(string Name)
    {
        //Using out Model, this line is validating our required conditions are being met in our Model.
        if (ModelState.IsValid)
        {
            //We only set the Session values if the user passes our validations
            HttpContext.Session.SetString("Username", Name);
            HttpContext.Session.SetInt32("Number", 22);
            return RedirectToAction("Dashboard");
        }
        else
        {
            return View("Index");
        }
    }

    [HttpGet("dashboard")]
    public IActionResult Dashboard()
    {
        //This line is used to avoid users attempting to view the Dashboard page through the URL.
        if(HttpContext.Session.GetString("Username") == null)
        {
            //If session doesnt have the user logged in, it will kick them back to the index
            return RedirectToAction("Index");
        }
        //GET both the string (to display the user name on the dashboard) and int (to display the Number)
        HttpContext.Session.GetString("Username");
        HttpContext.Session.GetInt32("Number");
        return View("Dashboard");
    }


    [HttpPost("plusone")]
    public IActionResult PlusOne()
    {
        //Session value is initially GET 
        int? count = HttpContext.Session.GetInt32("Number");
        //We take whatever session of Number currently us and use math to add session value by 1
        count+= 1;
        //Once we add by 1, we SET the new value in session.
        HttpContext.Session.SetInt32("Number", (int)count);
        return RedirectToAction("Dashboard");
    }

    [HttpPost("minusone")]
    public IActionResult MinusOne()
    {
        //Session value is initially GET 
        int? count = HttpContext.Session.GetInt32("Number");
        //We take whatever session of Number currently us and use math to subtract session value by 1
        count-= 1;
        //Once we subtract by 1, we SET the new value in session. 
        HttpContext.Session.SetInt32("Number", (int)count);
        return RedirectToAction("Dashboard");
    }

    [HttpPost("timestwo")]
    public IActionResult TimesTwo()
    {
        //Session value is initially GET 
        int? count = HttpContext.Session.GetInt32("Number");
        //We take whatever session of Number currently us and use math to multiply session value by 2
        count *= 2;
        //Once we multiply by 2, we SET the new value in session.
        HttpContext.Session.SetInt32("Number", (int)count);
        return RedirectToAction("Dashboard");
    }

    [HttpPost("randomone")]
    public IActionResult RandomOne()
    {
        //Random value between 1 and 10 (10 inclusive)
        Random random = new Random();
        int RandomValue = random.Next(1, 11);
        //Same math as other routes but count is increased based on the random value.
        int? count = HttpContext.Session.GetInt32("Number");
        count += RandomValue;
        //Printing random number to console to validate Sessions is updating correctly.
        System.Console.WriteLine($"Random number generated & added to count, {RandomValue}");
        HttpContext.Session.SetInt32("Number", (int)count);
        return RedirectToAction("Dashboard");
    }


    [HttpPost("logout")]
    public IActionResult Logout()
    {
        //Once button is clicked, session will be cleared and user will be redirected to Index
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
