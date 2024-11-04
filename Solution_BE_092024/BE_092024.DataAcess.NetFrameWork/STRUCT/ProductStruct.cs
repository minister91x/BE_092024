using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_092024.DataAcess.NetFrameWork.STRUCT
{
    public struct ProductStruct
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public ProductStruct(string _id, string _name,int _price, string _description)
        {
            ID = _id;
            Name = _name;
            Description = _description;
            Price=_price;
        }

        // tên hàm trùng với tên struct
        // hàm này không có kiểu trả về 
        // không có từ khóa return

        public string ProductInfor()
        {
            return "ID :" + ID + " | Name: " + Name + " | Description: " + Description;
        }

    }
}
