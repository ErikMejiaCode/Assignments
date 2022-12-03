using Microsoft.AspNetCore.Mvc;
namespace FirstWeb.Controllers;

public class HelloController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }

    [HttpPost("results")]
    public IActionResult Results(string name, string location, string language, string comment)
    {
        ViewBag.Name = name;
        ViewBag.Location = location;
        ViewBag.Language = language;
        ViewBag.Comment = comment;
        
        if (comment != null)
        {
            ViewBag.Comment = comment;
        } else {
            ViewBag.Comment = "No Comment";
        }
        return View("Results");
    }
}