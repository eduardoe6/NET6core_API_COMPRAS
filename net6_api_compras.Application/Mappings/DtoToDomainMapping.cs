using AutoMapper;
using net6_api_compras.Application.DTOs;
using net6_api_compras.Domain.Entities;

namespace net6_api_compras.Application.Mappings
{
    public class DtoToDomainMapping : Profile
    {
        public DtoToDomainMapping()
        {
            CreateMap<PersonDTO, Person>();
            CreateMap<ProductDTO, Product>();
        }
    }
}
