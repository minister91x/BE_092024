using BE_092024.DataAcess.NetFrameWork.DataObject;
using BE_092024.DataAcess.NetFrameWork.STRUCT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_092024.DataAcess.NetFrameWork.Interface
{
    public interface IProduct
    {
        ProductInsertReponseData Product_Insert(Product product); // trừu tượng
    }
}
