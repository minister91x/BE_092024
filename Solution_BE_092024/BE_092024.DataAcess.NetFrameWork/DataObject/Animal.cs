using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_092024.DataAcess.NetFrameWork.DataObject
{
    public class Animal
    {
        // tường minh 
        // get : cho phép lấy dữ liệu từ thuộc tính Name ra bên ngoài
        // set :cho phép đưa dữ liệu từ thuộc tính Name ra bên ngoài
        public string Name { get; set; }
        //public string Name1 { return Name; set; }
        // Contructor 
        // không có kiểu trả về 
        // Tên hàm phải trùng với tên class

        public string GetName()
        {
            return Name;
        }

        public void Show()
        {

        }
    }
}
