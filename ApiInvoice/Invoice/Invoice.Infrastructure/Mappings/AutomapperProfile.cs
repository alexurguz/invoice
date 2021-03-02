using AutoMapper;
using Invoice.Core.DTOs;
using Invoice.Core.Entities;

namespace Invoice.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Product, ProductDto>().ForMember(dest => dest.IdProduct, opt => opt.MapFrom(src => src.id));
            CreateMap<ProductDto, Product>().ForMember(dest => dest.id, opt => opt.MapFrom(src => src.IdProduct));
            CreateMap<SalesInvoice, SalesInvoiceDto>().ForMember(dest => dest.IdSalesInvoice, opt => opt.MapFrom(src => src.id));
            CreateMap<SalesInvoiceDto, SalesInvoice>().ForMember(dest => dest.id, opt => opt.MapFrom(src => src.IdSalesInvoice));
            CreateMap<SalesInvoiceProducts, SalesInvoiceProductsDto>().ForMember(dest => dest.IdSalesInvoiceProduct, opt => opt.MapFrom(src => src.id));
            CreateMap<SalesInvoiceProductsDto, SalesInvoiceProducts>().ForMember(dest => dest.id, opt => opt.MapFrom(src => src.IdSalesInvoiceProduct));
            CreateMap<User, UserDto>().ForMember(dest => dest.IdUser, opt => opt.MapFrom(src => src.id));
            CreateMap<UserDto, User>().ForMember(dest => dest.id, opt => opt.MapFrom(src => src.IdUser));
        }
    }
}
