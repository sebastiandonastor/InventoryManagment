using AutoMapper;
using InventoryManagment.Application.DTOs;
using InventoryManagment.Domain;

namespace InventoryManagment.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Vendor, VendorDto>().ReverseMap();
            CreateMap<StockProduct, StockProductDto>().ReverseMap();
        }
    }
}
