using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ChefsAndDishes.Models;

namespace ChefsAndDishes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    //Home page, shows a table to chefs and includes the count for amount of dishes per chef
    public IActionResult Index()
    {
        List<Chef> AllChefs = _context.Chefs.Include(d => d.AllDishes).ToList();
        return View("Index", AllChefs);
    }


    //Get method that takes us to the Chef create page 
    [HttpGet("chefs/new")]
    public IActionResult NewChef()
    {
        // MyViewModel MyModel = new MyViewModel
        // {
        //     AllChefs = _context.Chefs.ToList()
        // };
        return View("NewChef");
    }

    //Post method that will take the form data and update it to our database
    [HttpPost("chef/create")]
    public IActionResult CreateChef(Chef newChef)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } else 
        {
            return View("NewChef", newChef);
        }
    }


    ////Get method that takes us to the Dish create page 
    [HttpGet("dishes/new")]
    public IActionResult NewDish()
    {
        ViewBag.Chefs = _context.Chefs.ToList();
        return View("NewDish");
    }

    //Post method that will take the form data and update it to our database
    [HttpPost("dishes/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Dishes");
        } else 
        {
            ViewBag.Chefs = _context.Chefs.ToList();
            return View("NewDish");
        }
    }

    [HttpGet("dishes")]
    public IActionResult Dishes()
    {
        List<Dish> AllDishes = _context.Dishes.Include(c => c.Chef).ToList();
        return View("Dishes", AllDishes);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
