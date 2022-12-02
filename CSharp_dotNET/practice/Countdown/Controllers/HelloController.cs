using Microsoft.AspNetCore.Mvc;
namespace FirstWeb.Controllers;

public class HelloController : Controller
{
    [HttpGet]
    [Route("")]
    public ViewResult Index()
    {
        return View("Index");
    }
}