using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_092024.DataAcess.NetFrameWork.DataObject
{
    public abstract class AnimalAbstract
    {
        public  string Name { get; }

        public abstract string GetSound(); // trừu tượng 
        public virtual string GetName()
        {
            return Name;
        }
    }
}
