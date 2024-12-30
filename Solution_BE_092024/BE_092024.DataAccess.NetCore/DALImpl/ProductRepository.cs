using BE_092024.Common.DbHelper;
using BE_092024.DataAccess.NetCore.DAL;
using BE_092024.DataAccess.NetCore.Dapper;
using BE_092024.DataAccess.NetCore.DataObject;
using BE_092024.DataAccess.NetCore.DBContext;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_092024.DataAccess.NetCore.DALImpl
{
    public class ProductRepository :BaseApplicationService, IProductRepository
    {

        private BE_092924DbContext _dbContext;
       
        public ProductRepository(IServiceProvider serviceProvider, BE_092924DbContext dbContext) : base(serviceProvider)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> Product_GetList(ProductGetListRequestData requestData)
        {
            var list = new List<Product>();
            try
            {
                // Bước 1: mở connection 
                var conn = new SqlConnectionDB().DoConnect();

                //Bước 2:Sử dụng SqlCommand để thao tác với DataBase 
                var cmd = new SqlCommand("SP_Product_GetList", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // bƯỚC 3: thêm tham số cho Store 
                cmd.Parameters.AddWithValue("@ProductName", requestData.ProductName);

                // bƯỚC 4: nHẬN KẾT QUẢ

                var rs = await cmd.ExecuteReaderAsync(); // trả về bảng 
                while (rs.Read())
                {
                    var product = new Product();

                    product.ProductId = rs["ProductId"] != null ? Convert.ToInt32(rs["ProductId"].ToString()) : 0;
                    product.ProductName = rs["ProductName"] != null ? rs["ProductName"].ToString() : string.Empty;

                    list.Add(product);  
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }

            await Task.Yield();

            return list;
        }

        public async Task<List<Product>> Product_GetList_Dapper(ProductGetListRequestData requestData)
        {
            try
            {
                // bƯỚC 1 : Khởi tạo param 
                var parameters = new DynamicParameters();
                parameters.Add("@ProductName", requestData.ProductName);
                return await DbConnection.QueryAsync<Product>("SP_Product_GetList", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Product>> Product_GetList_EFCore(ProductGetListRequestData requestData)
        {
            try
            {
                var productDb =  _dbContext.product.ToList();

                if (!string.IsNullOrEmpty(requestData.ProductName))
                {
                    productDb = productDb.FindAll(s=>s.ProductName.Contains(requestData.ProductName)).ToList();
                }

                return productDb;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<int> Product_Insert(Product product)
        {
            _dbContext.product.Add(product);
            return 1;
        }
    }
}
