using BE_092024.DataAccess.NetCore.DAL;

namespace BE_092024_API.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRoomGenericRepository _roomGenericRepository { get; set; }
        IProductRepository _productRepository { get; set; }

        int SaveChange();
    }
}
