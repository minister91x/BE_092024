using BE_092024.Common;
using BE_092024.DataAcess.NetFrameWork.DataObject;
using BE_092024.DataAcess.NetFrameWork.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_092024.DataAcess.NetFrameWork.Interface
{
    public class ProductManager : IProduct
    {
        public List<Product> products = new List<Product>();
        public ProductInsertReponseData Product_Insert(Product product)
        {
            var returnData = new ProductInsertReponseData();
            try
            {
                /// code xử lý
                // Bước 2.1 : 
                if (product == null
                    || string.IsNullOrEmpty(product.Name)
                    || product.Id <= 0)
                {
                    returnData.ReponseCode =(int)ProductInsertStatus.DataInvalid;
                    returnData.ResponseMessenger = "Dữ liệu đầu vào không hợp lệ!";
                    return returnData;
                }

                // Kiểm tra xem Name có rủi ro gì không ( javascript , thẻ html ... ký tự đặc biêt..)
                if (!Validation.CheckString(product.Name))
                {
                    returnData.ReponseCode = (int)ProductInsertStatus.ProductNameNull;
                    returnData.ResponseMessenger = "ProductName không hợp lệ!";
                    return returnData;
                }

                if (!Validation.CheckXSSInput(product.Name))
                {
                    returnData.ReponseCode = (int)ProductInsertStatus.InvalidXSSInput;
                    returnData.ResponseMessenger = "ProductName không hợp lệ!";
                    return returnData;
                }


                // kiểm tra trùng  c1
                //var isExits = products.FindAll(s => s.Name == product.Name).Any() ? true : false;
                //if (isExits)
                //{
                //    returnData.ReponseCode = -4;
                //    returnData.ResponseMessenger = "ProductName đã tồn tại!";
                //    return returnData;
                //}

                // kiểm tra trùng  c2
                var isExits = true;
                if (products.Count > 0)
                {
                    foreach (var item in products)
                    {
                        if (item.Name.Equals(product.Name)) { isExits = false; break; }
                    }
                }

                if (!isExits)
                {
                    returnData.ReponseCode = (int)ProductInsertStatus.Dupplicate;
                    returnData.ResponseMessenger = "ProductName đã tồn tại!";
                    return returnData;
                }



                products.Add(product);

                returnData.ReponseCode = (int)ProductInsertStatus.Success;
                returnData.ResponseMessenger = "ProductName không hợp lệ!";
                return returnData;
            }
            catch (Exception ex)
            {
                returnData.ReponseCode = -99;
                returnData.ResponseMessenger = ex.StackTrace;
                return returnData;
            }

            return returnData;
        }
    }
}
