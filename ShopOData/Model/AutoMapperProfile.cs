
using AutoMapper;
using ShopBussinessObject;
using ShopDataAccess;
using ShopDTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ShopOData.Model
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDTO>().ForMember(desc => desc.CategoryName, o => o.MapFrom(src => src.Category.CategoryName));
            CreateMap<Category, CategoryDTO>();
        }
    }
}