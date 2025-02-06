using System.ComponentModel.DataAnnotations;

namespace BE_092024_WebAspnetCore.Models
{
    public class ProductModels
    {
        public int ProductId { get; set; }

        
        [Required(ErrorMessage ="Tên sản phẩm không được trống")]
        [MaxLength(2)]
        public string? ProductName { get; set; }

        [Required(ErrorMessage ="Số lượng không được quá 100")]
        [MaxLength (2)]
        public int Quantity {  get; set; }
    }
    public class ProductModels1
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
    }
}
