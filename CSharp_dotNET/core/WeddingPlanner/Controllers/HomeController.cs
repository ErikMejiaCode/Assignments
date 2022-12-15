using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    //**************************** Routes for the User pages *********************************//

    //Default controller route to index where the login and reg page will be housed. 
    [HttpGet("")]
    public IActionResult Index()
    {
        return View("Index");
    }


    //Post route used to process the forms submitted by users wanting to register 
    [HttpPost("users/create")]
    public IActionResult CreateUser(User newUser)
    {
        if (ModelState.IsValid)
        {
            //Hash our passwords | After validations are done 
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            //Add to db and save changes
            _context.Add(newUser);
            _context.SaveChanges();
            //set session and head to Dashboard
            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            HttpContext.Session.SetString("Username", newUser.FirstName);
            return RedirectToAction("Weddings");
        }
        else
        {
            return View("Index");
        }
    }


    //Post route used to process the forms submitted by users wanting to register 
    [HttpPost("users/login")]
    public IActionResult UserLogin(LoginUser LogUser)
    {
        if (ModelState.IsValid)
        {
            //Look up our user in the database
            User? userInDb = _context.Users.FirstOrDefault(u => u.Email == LogUser.LEmail);
            //Verify user exists
            if (userInDb == null)
            {
                ModelState.AddModelError("LEmail", "Invalid Email/Password");
                return View("Index");
            }
            //Verify if the password match what is in the database
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            var result = hasher.VerifyHashedPassword(LogUser, userInDb.Password, LogUser.LPassword);
            if (result == 0)
            {
                //A failure, we did not use the right password 
                ModelState.AddModelError("LEmail", "Invalid Email/Password");
                return View("Index");
            }
            else
            {
                //set session and head to Weddings
                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                HttpContext.Session.SetString("Username", userInDb.FirstName);
                return RedirectToAction("Weddings");
            }
        }
        else
        {
            return View("Index");
        }
    }


    //Logout route in order to clear our session 
    [SessionCheck]
    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return View("Index");
    }



    //**************************** Routes for the Wedding pages *********************************//



    //Dashboard route to page if user successfully registers or logs in 
    [SessionCheck]
    [HttpGet("weddings")]
    public IActionResult Weddings()
    {
        MyViewModel MyModel = new MyViewModel
        {
            AllWeddings = _context.Weddings.Include(a => a.Listings).ThenInclude(u => u.User).ToList()
        };
        return View("Weddings", MyModel);
    }


    [SessionCheck]
    [HttpGet("weddings/new")]
    public IActionResult NewWedding()
    {
        return View();
    }


    //User id is needed in order to correct the Foreign Key error
    [SessionCheck]
    [HttpPost("weddings/create")]
    public IActionResult CreateWedding(Wedding newWedding)
    {
        newWedding.UserId = (int)HttpContext.Session.GetInt32("UserId");
        if (ModelState.IsValid)
        {
            _context.Add(newWedding);
            _context.SaveChanges();
            return RedirectToAction("Weddings");
        } else {
        return View("NewWedding");
        }
    }


    [SessionCheck]
    [HttpPost("weddings/{WeddingId}/destroy")]
    public IActionResult DestroyWedding(int WeddingId)
    {
        Wedding? weddingToDelete = _context.Weddings.SingleOrDefault(w => w.WeddingId == WeddingId);
        if (weddingToDelete != null)
        {
            _context.Weddings.Remove(weddingToDelete);
            _context.SaveChanges();
            return RedirectToAction("Weddings");
        }
        MyViewModel MyModel = new MyViewModel
        {
            AllWeddings = _context.Weddings
                .Include(w => w.Listings)
                .ThenInclude(a => a.User)
                .ToList()
        };
        return View("Weddings", MyModel);
    }


    [SessionCheck]
    [HttpPost("associations/{WeddingId}/create")]
    public IActionResult RSVP(int WeddingId)
    {
        Association newAssociation = new Association();
        newAssociation.WeddingId = WeddingId;
        newAssociation.UserId = (int)HttpContext.Session.GetInt32("UserId");
        _context.Associations.Add(newAssociation);
        _context.SaveChanges();
        return RedirectToAction("Weddings");
    }


    [SessionCheck]
    [HttpPost("associations/{WeddingId}/destroy")]
    public IActionResult UnRSVP(int WeddingId)
    {
        int userId = (int)HttpContext.Session.GetInt32("UserId");
        Association? assocToDestroy = _context.Associations.SingleOrDefault(a => a.UserId == userId && a.WeddingId == WeddingId);
        if (assocToDestroy != null)
        {
            _context.Associations.Remove(assocToDestroy);
            _context.SaveChanges();
            return RedirectToAction("Weddings");
        }
        MyViewModel MyModel = new MyViewModel
        {
            AllWeddings = _context.Weddings
                .Include(w => w.Listings)
                .ThenInclude(a => a.User)
                .ToList()
        };
        return View("Weddings");
    }



    [HttpGet("weddings/{WeddingId}")]
    public IActionResult ShowWedding(int WeddingId)
    {   
        MyViewModel MyModel = new MyViewModel
        {
            Wedding = _context.Weddings
                .Include(w => w.Listings)
                .ThenInclude(a => a.User)
                .FirstOrDefault(f => f.WeddingId == WeddingId)
        };
        if (MyModel.Wedding != null) {
            return View("ShowWedding", MyModel);
        } else {
            return RedirectToAction("Weddings");
        }
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


    //Custom session check 
    public class SessionCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int? userId = context.HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }

