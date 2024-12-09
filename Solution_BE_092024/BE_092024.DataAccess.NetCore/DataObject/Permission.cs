using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_092024.DataAccess.NetCore.DataObject
{
    public class Permission
    {
        [Key]
        public int PermissionID { get; set; }
        public int UserID { get; set; }
        public int FunctionID { get; set; }
        public int IsView { get; set; }
        public int IsInsert { get; set; }
        public int IsUpdate { get; set; }
    }
}
