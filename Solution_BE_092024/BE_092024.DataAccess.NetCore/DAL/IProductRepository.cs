using BE_092024.DataAccess.NetCore.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_092024.DataAccess.NetCore.DAL
{
    public interface IProductRepository
    {
        Task<List<Product>> Product_GetList(ProductGetListRequestData requestData);

        Task<List<Product>> Product_GetList_EFCore(ProductGetListRequestData requestData);

        Task<int> Product_Insert(Product product);


        Task<List<Product>> Product_GetList_Dapper(ProductGetListRequestData requestData);
    }
}
