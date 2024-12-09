using BE_092024.DataAccess.NetCore.DAL;
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
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost("Product_GetList")]
        [BE_092024_Authorization("Product_GetList", "VIEW")]// 
        public async Task<ActionResult> Product_GetList(ProductGetListRequestData requestData)
        {
            var list = await _productRepository.Product_GetList_EFCore(requestData);

            return Ok(list);
        }

    }
}
