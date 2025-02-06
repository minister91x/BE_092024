using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_092024.DataAccess.NetCore.DataObject
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
    }

    public class ProductGetListRequestData
    {
        
        public string? ProductName { get; set; }
    }
}
