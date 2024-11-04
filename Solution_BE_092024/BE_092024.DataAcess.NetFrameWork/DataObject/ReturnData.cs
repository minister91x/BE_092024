using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_092024.DataAcess.NetFrameWork.DataObject
{
    public class ReturnData
    {
        public int ReponseCode { get; set; }
        public string ResponseMessenger { get; set; }
    }

    public class ProductInsertReponseData : ReturnData
    {

    }
}
