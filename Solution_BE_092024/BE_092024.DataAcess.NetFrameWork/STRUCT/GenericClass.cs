using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_092024.DataAcess.NetFrameWork.STRUCT
{
    public struct GenericStruct<T>
    {
        public T myPropertiesGeneric;

        // Constructor
        public GenericStruct(T val)
        {
            myPropertiesGeneric = val;
        }

        public T GetValue()
        {
            return myPropertiesGeneric;
        }

    }
}
