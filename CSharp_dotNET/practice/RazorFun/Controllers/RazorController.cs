using Microsoft.AspNetCore.Mvc;
namespace Portfolio1;

public class RazorController : Controller
{
    [HttpGet]
    [Route("")]
    public ViewResult Index()
    {
        return View("Index");
    }
}