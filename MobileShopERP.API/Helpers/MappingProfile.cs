using AutoMapper;
using MobileShopERP.API.DTOs;
using MobileShopERP.API.Models;

namespace MobileShopERP.API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Product mappings
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // User mappings
            CreateMap<User, UserDto>();
            CreateMap<RegisterDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));

            // Customer mappings
            CreateMap<Customer, CustomerDto>();
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<UpdateCustomerDto, Customer>();

            // Supplier mappings
            CreateMap<Supplier, SupplierDto>();
            CreateMap<CreateSupplierDto, Supplier>();
            CreateMap<UpdateSupplierDto, Supplier>();

            // Sale mappings
            CreateMap<Sale, SaleDto>()
                .ForMember(dest => dest.CustomerName, 
                    opt => opt.MapFrom(src => src.Customer != null ? src.Customer.Name : "Walk-in Customer"))
                .ForMember(dest => dest.CashierName, 
                    opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.Items, 
                    opt => opt.MapFrom(src => src.SaleItems));
            
            CreateMap<SaleItem, SaleItemDto>()
                .ForMember(dest => dest.ProductName, 
                    opt => opt.MapFrom(src => src.Product.Name));
        }
    }
}