using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_092024.DataAccess.NetCore.DataObject
{
    public class User_Sessions
    {
        public int UserId { get; set; }
        public string? token { get; set; }
        public string? deviceID { get; set; }
        public DateTime createdTime { get; set; }
    }
}
