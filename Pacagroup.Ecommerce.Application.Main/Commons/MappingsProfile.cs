using AutoMapper;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Domain.Entity;

namespace Pacagroup.Ecommerce.Application.Main.Commons;

public class MappingsProfile : Profile
{
    public MappingsProfile()
    {
        //Mapeo siempre y cuando tenga la misma propiedades,
        //Si tienen diferentes propiedades se hace de forma manual
        //[Metodo Mapeo] [Dto, Entidad] [Metodo mapeo reverso]
        CreateMap<CustomerDto, Customer>().ReverseMap();

        // Mapeo manual: se especifica cada propiedad
        //CreateMap<CustomerDto, Customer>()
        //    .ForMember(dest => dest.CustomerID, opt => opt.MapFrom(src => src.CustomerID))
        //    .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.CompanyName))
        //    .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.ContactName))
        //    .ForMember(dest => dest.ContactTitle, opt => opt.MapFrom(src => src.ContactTitle))
        //    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
        //    .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
        //    .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Region))
        //    .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode))
        //    .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
        //    .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
        //    .ForMember(dest => dest.Fax, opt => opt.MapFrom(src => src.Fax));

        // Mapeo manual inverso
        //CreateMap<Customer, CustomerDto>()
        //    .ForMember(dest => dest.CustomerID, opt => opt.MapFrom(src => src.CustomerID))
        //    .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.CompanyName))
        //    .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.ContactName))
        //    .ForMember(dest => dest.ContactTitle, opt => opt.MapFrom(src => src.ContactTitle))
        //    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
        //    .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
        //    .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Region))
        //    .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode))
        //    .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
        //    .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
        //    .ForMember(dest => dest.Fax, opt => opt.MapFrom(src => src.Fax));


    }

}
