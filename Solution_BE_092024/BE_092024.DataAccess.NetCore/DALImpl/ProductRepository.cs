using BE_092024.DataAccess.NetCore.DAL;
using BE_092024.DataAccess.NetCore.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_092024.DataAccess.NetCore.DALImpl
{
    public class ProductRepository : IProductRepository
    {
        public async Task<List<Product>> Product_GetList(ProductGetListRequestData requestData)
        {
            var list = new List<Product>();
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    list.Add(new Product { ProductId = i, Name = "Product " + i });
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            await Task.Yield();

            return list;
        }
    }
}
