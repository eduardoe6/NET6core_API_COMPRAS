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
        }
    }
}
