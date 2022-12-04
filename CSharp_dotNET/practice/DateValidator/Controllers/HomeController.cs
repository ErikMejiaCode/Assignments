using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DateValidator.Models;

namespace DateValidator.Controllers;

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

    [HttpPost("process")]
    public IActionResult Process(Date Instance)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Success", Instance);
        } 
        else 
        {
        return View("Index");
        }
    }

    [HttpGet("success")]
    public IActionResult Success(Date Instance)
    {
        return View("Success", Instance);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
