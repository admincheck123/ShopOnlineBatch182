using System.ComponentModel.DataAnnotations;

namespace ShopDTO
{
    public class ProductDTO
    {
        [Display(Name = "Mã sản phẩm ")]
        public int ProductId { get; set; }
        [Display(Name = "Tên sản phẩm ")]
        public string ProductName { get; set; }
        [Display(Name = "Nhóm sản phẩm ")]
        public int CategoryId { get; set; }
        [Display(Name = "Tên nhóm sản phẩm ")]
        public string CategoryName { get; set; }
    }
}    