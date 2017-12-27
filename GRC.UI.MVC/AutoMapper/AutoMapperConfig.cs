using Application.Models.Category;
using Application.Models.Product;
using Application.Models.Shop;
using AutoMapper;
using Domain.Entities;

namespace GRC.UI.MVC
{
    public class AutoMapperConfig
    {
        /// <summary>
        /// Map Model -> Entities
        /// </summary>
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Category, ListGridCategoryModel>().ReverseMap();
                cfg.CreateMap<Category, CreateCategoryModel>().ReverseMap();
                cfg.CreateMap<Category, EditCategoryModel>().ReverseMap();
                cfg.CreateMap<Product, ListGridProductModel>().ForMember(dto => dto.CategoryName, opt => opt.MapFrom(src => src.Category.Name)).ReverseMap();
                cfg.CreateMap<Product, ShopModel>().ForMember(dto => dto.CategoryName, opt => opt.MapFrom(src => src.Category.Name)).ReverseMap();
                cfg.CreateMap<Product, CreateProductModel>().ReverseMap();
                cfg.CreateMap<Product, EditProductModel>().ReverseMap();
            });
        }
    }
}