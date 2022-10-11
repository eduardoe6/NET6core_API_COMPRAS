using AutoMapper;
using net6_api_compras.Application.DTOs;
using net6_api_compras.Domain.Entities;

namespace net6_api_compras.Application.Mappings
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<Person, PersonDTO>();

            CreateMap<Product, ProductDTO>();

            CreateMap<Purchase, PurchaseDetailDTO>()
                .ForMember(x => x.Person, opt => opt.Ignore())
                .ForMember(x => x.Product, opt => opt.Ignore())
                .ConstructUsing((model, context) =>
                {
                    var dto = new PurchaseDetailDTO
                    {
                        Id = model.Id,
                        Person = model.Person.Name,
                        Product = model.Product.Name,
                        Date = model.Date
                    };

                    return dto;
                });
        }
    }
}
