using BE_092024.DataAccess.NetCore.DAL;
using BE_092024.DataAccess.NetCore.Dapper;
using BE_092024.DataAccess.NetCore.DataObject;
using BE_092024_API.Filter;
using BE_092024_API.LogConfig;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BE_092024_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;
        private IApplicationDbConnection _application;
        private ILogger<ProductController> _logger;
        private readonly ILoggerManager _loggerManager;

        public ProductController(IProductRepository productRepository,
            IApplicationDbConnection application,
            ILogger<ProductController> logger, ILoggerManager loggerManager)
        {
            _productRepository = productRepository;
            _application = application;
            _logger = logger;
            _loggerManager = loggerManager;
        }

        [HttpPost("Product_GetList")]
        // [BE_092024_Authorization("Product_GetList", "VIEW")]// 
        public async Task<ActionResult> Product_GetList(ProductGetListRequestData requestData)
        {
            var logID = DateTime.Now.Ticks;
            var list = new List<Product>();
            try
            {
                _loggerManager.LogInfo("logID:" + logID + "|" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " | RequestData:" + JsonConvert.SerializeObject(requestData));
                list = await _productRepository.Product_GetList_Dapper(requestData);
                _loggerManager.LogInfo("logID:" + logID+ "|" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " | Response:" + JsonConvert.SerializeObject(list));

            }
            catch (Exception ex)
            {
                _loggerManager.LogError("logID:" + logID + "|" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " | ex:" + ex.StackTrace);
            }


            return Ok(list);
        }

    }
}
