using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FOrmSubmission.Models;

namespace FOrmSubmission.Controllers;

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

    [HttpPost("results")]
    public IActionResult Results(User Instance)
    {
        if (ModelState.IsValid)
        {
            return View("Results", Instance);
        }
        else 
        {
        return View("Index");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
