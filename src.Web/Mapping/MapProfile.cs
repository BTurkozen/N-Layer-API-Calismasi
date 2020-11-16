using AutoMapper;
using src.Core.Models;
using src.Web.DTOs;

namespace src.Web.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            //Category için mapper
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryWithProductDto>();
            CreateMap<CategoryWithProductDto, Category>();

            //Product için mapper
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductWithCategoryDto>();
            CreateMap<ProductWithCategoryDto, Product>();




        }
    }
}
