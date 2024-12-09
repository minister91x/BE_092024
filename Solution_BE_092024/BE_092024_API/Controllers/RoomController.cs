using BE_092024.DataAccess.NetCore.DAL;
using BE_092024.DataAccess.NetCore.DALImpl;
using BE_092024.DataAccess.NetCore.UnitOfWork;
using BE_092024_API.Filter;
using BE_092024_API.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_092024_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        //  private readonly IRoomGenericRepository _roomGenericRepository;
        //public RoomController(IRoomGenericRepository roomGenericRepository)
        //{
        //    _roomGenericRepository = roomGenericRepository;
        //}
        private IUnitOfWork _unitOfWork;

        public RoomController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("Room_GetList")]
        //[BE_092024_Authorization()]// 
        public async Task<ActionResult> Room_GetList()
        {
            try
            {

                //   var list = await _roomGenericRepository.GetAllAsync();
                var list = await _unitOfWork._roomGenericRepository.GetAllAsync();

                var rs = _unitOfWork._productRepository.Product_GetList(new BE_092024.DataAccess.NetCore.DataObject.ProductGetListRequestData { ProductName = "" });



                return Ok(list);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost("Insert")]
        public async Task<ActionResult> Insert()
        {
            try
            {
                var list = await _unitOfWork._roomGenericRepository.Insert(new BE_092024.DataAccess.NetCore.DataObject.Room
                {
                    Name = "abc",
                    Description = "test"
                });

                var rs = _unitOfWork._productRepository.Product_Insert(new BE_092024.DataAccess.NetCore.DataObject.Product
                {
                    ProductName = "P123"
                });

                var rs_save = _unitOfWork.SaveChange();

                return Ok(rs_save);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
