using BE_092024_WebAspnetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BE_092024_WebAspnetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index(int? id)
        {
            var model = new List<ProductModels>();
            try
            {
                //if (true)
                //{
                //    return Redirect("/Account/Login");
                //}

                for (int i = 0; i < 10; i++)
                {
                    model.Add(new ProductModels { ProductId = i, ProductName = "DELL " + i });
                }


            }
            catch (Exception ex)
            {

                throw;
            }
            return View(model);
        }

      
        public ActionResult Index1()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
