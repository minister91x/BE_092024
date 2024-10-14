using BE_092024.DataAcess.NetFrameWork.STRUCT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_092024.DataAcess.NetFrameWork.Bussiness
{
    public class ProductManagerment
    {
        public string Product_Insert(string id, string name, string price, string desc)
        {
            // Validation Data
            var checkid = BE_092024.Common.Validation.CheckString(id);
          
            if (!checkid)
            {
                return "ID không hợp lệ";
            }

            var checkname = BE_092024.Common.Validation.CheckString(name);

            if (!checkname)
            {
                return "Tên không hợp lệ";
            }

            var checkprice = BE_092024.Common.Validation.CheckNumber(price);
            if (!checkprice)
            {
                return "giá bán không hợp lệ";
            }


            var checkdesc = BE_092024.Common.Validation.CheckString(desc);

            if (!checkdesc)
            {
                return "Mô tả không hợp lệ";
            }

            // Xử lý logic 

            var product = new Product();
            product.ID = id;
            product.Name = name;
            product.Price = Convert.ToInt32(price);
            product.Description = desc;

            return product.ProductInfor();
        }
    }
}
