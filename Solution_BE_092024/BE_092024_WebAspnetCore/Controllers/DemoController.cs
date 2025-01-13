using Microsoft.AspNetCore.Mvc;

namespace BE_092024_WebAspnetCore.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
