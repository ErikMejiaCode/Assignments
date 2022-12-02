using Microsoft.AspNetCore.Mvc;
namespace Portfolio2;

public class HomeController : Controller
{
    [HttpGet]
    [Route("")]
    public ViewResult Index()
    {
        return View("Index");
    }

    [HttpGet("Projects")]
    public ViewResult Projects()
    {
        return View("Projects");
    }

    [HttpGet("Contact")]
    public ViewResult Contact()
    {
        return View("Contact");
    }
}