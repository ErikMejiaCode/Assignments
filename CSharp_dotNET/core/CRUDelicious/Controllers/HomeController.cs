using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    //Home page, used to display all our dishes
    [HttpGet("")]
    public IActionResult Index()
    {
        List<Dish> AllDishes = _context.Dishes.ToList();
        return View("Index", AllDishes);
    }

    //Create a new dish, Route to create new dish and adding that to our database
    [HttpPost("dish/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } else 
        {
            return View("CreateDish", newDish);
        }
    }

    //Route used to navigate to our Create dish page. Only GET is needed
    [HttpGet("dishes/new")]
    public IActionResult NewDish()
    {
        return View("CreateDish");
    }


    //Route used to display only 1 dish. GET method is only needed
    [HttpGet("dishes/{id}")]
    public IActionResult ShowDish(int id)
    {
        Dish? OneDish = _context.Dishes.FirstOrDefault(a => a.DishId == id);
        if(OneDish != null){
        return View("OneDish", OneDish);
        } else {
            return RedirectToAction("Index");
        }
    }

    //Route used to delete Songs from our database 
    [HttpPost("dishes/{dishId}/destroy")]
    public IActionResult DestroyDish(int dishId)
    {
        //deleting song from our database
        Dish? DishToDestroy = _context.Dishes.SingleOrDefault(a => a.DishId == dishId);
        _context.Dishes.Remove(DishToDestroy);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    //Route used to take us to the edit screen. 
    [HttpGet("dishes/{DishId}/edit")]
    public IActionResult EditDish(int DishId)
    {
        Dish? DishToEdit = _context.Dishes.FirstOrDefault(a => a.DishId == DishId);
        return View(DishToEdit);
    }

    //Route used to update the Dish information in our Database.
    [HttpPost("dishes/{dishId}/update")]
    public IActionResult UpdateDish(int dishId, Dish UpdatedDish)
    {
        Dish? DishToUpdate = _context.Dishes.FirstOrDefault(a => a.DishId == dishId);
        if (DishToUpdate == null) 
        {
            return RedirectToAction("EditDish");
        }
        if (ModelState.IsValid)
        {
            DishToUpdate.Name = UpdatedDish.Name;
            DishToUpdate.Chef = UpdatedDish.Chef;
            DishToUpdate.Calories = UpdatedDish.Calories;
            DishToUpdate.Description = UpdatedDish.Description;
            DishToUpdate.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Index");
        } else {
            return View("EditDish", DishToUpdate);
        }
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
