using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_092024.DataAcess.NetFrameWork.Enum
{
    public enum ProductInsertStatus
    {

        Success = 1,
        DataInvalid = -1,
        ProductNameNull = -2,
        InvalidXSSInput = -3,
        Dupplicate = -4
    }
}
