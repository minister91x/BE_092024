using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_092024.DataAcess.NetFrameWork.DataObject
{
    public class Person
    {
        private string fullName { get; set; }

        public Person(string _fullName) {
         
            this.fullName = _fullName;
          
        }
        public string FullName()
        {
            return fullName;
        }

    }
}
