using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_092024.DataAccess.NetCore.DataObject.Response
{
    public class UserLoginResponseData : ResponseData
    {
       public string FullName {  get; set; }
        public string token {  get; set; }
    }
}
