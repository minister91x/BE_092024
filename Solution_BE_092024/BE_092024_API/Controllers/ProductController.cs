using BE_092024.DataAccess.NetCore.DAL;
using BE_092024.DataAccess.NetCore.Dapper;
using BE_092024.DataAccess.NetCore.DataObject;
using BE_092024_API.Filter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_092024_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;
        private IApplicationDbConnection _application;
        public ProductController(IProductRepository productRepository, IApplicationDbConnection application)
        {
            _productRepository = productRepository;
            _application = application;
        }

        [HttpPost("Product_GetList")]
       // [BE_092024_Authorization("Product_GetList", "VIEW")]// 
        public async Task<ActionResult> Product_GetList(ProductGetListRequestData requestData)
        {
              var list = await _productRepository.Product_GetList_Dapper(requestData);
         
            return Ok(list);
        }

    }
}
