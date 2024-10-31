using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_092024.DataAcess.NetFrameWork.DataObject
{
    public class Bird 
    {
        public string ShowName()
        {
            var animal = new Animal();

            return animal.Name; 
        }
    }
}
