using System.ComponentModel.DataAnnotations;

namespace ShopDTO
{
    public class CategoryDTO
    {
        [Display(Name = "Mã nhóm sản phẩm ")]
        public int CategoryId { get; set; }
        [Display(Name = "Tên nhóm sản phẩm ")]
        public string CategoryName { get; set; }


    }
}