using Microsoft.AspNetCore.Mvc;
namespace Portfolio1;

public class MainController : Controller
{
    [HttpGet]
    [Route("")]
    public ViewResult Index()
    {
        return View("Index");
    }

    [HttpGet("projects")]
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