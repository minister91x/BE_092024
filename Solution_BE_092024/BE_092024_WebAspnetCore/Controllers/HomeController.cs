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
            return View();
        }

        public IActionResult ListProductPartialViews()
        {
            var model = new List<ProductModels>();
            try
            {
                //if (true)
                //{
                //    return Redirect("/Account/Login");
                //}

                // Tìm thư mục Views => Tìm thư mục trùng tên của controller => tìm đến file .cshtml cùng 
                // tên của action 
                // Views/Home/Index.cshtml 
                // Views/Custome/Index.cshtml
                for (int i = 0; i < 10; i++)
                {
                    model.Add(new ProductModels { ProductId = i, ProductName = "DELL " + i });
                }


            }
            catch (Exception ex)
            {

                throw;
            }
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult Index(ProductModels model)
        {
            var rs = new ReturnData();
            try
            {

                if (!ModelState.IsValid)
                {
                    return View();
                }

                if(model==null 
                    || string.IsNullOrEmpty(model.ProductName)
                    || model.Quantity <= 0)
                {
                    rs.ResponseCode = -1;
                    rs.ResponseMsg = "Dữ liệu đầu vào không hợp lệ!";
                    return Json(rs);
                }

                // check 
                if (!BE_092024.Common.Validation.CheckXSSInput(model.ProductName))
                {
                    rs.ResponseCode = -2;
                    rs.ResponseMsg = "Tên sản phẩm không hợp lệ!";
                    return Json(rs);
                }

                // đưa vào db


                rs.ResponseCode = 1;
                rs.ResponseMsg = "Thêm sản phẩm thành công!";
                return Json(rs);

            }
            catch (Exception ex)
            {
                rs.ResponseCode = -969;
                rs.ResponseMsg = ex.Message;
                return Json(rs);
            }
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
