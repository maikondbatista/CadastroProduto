using AutoMapper;
using Products.Domain.Dtos;
using Products.Domain.Entites;

namespace Products.Infra.CrossCutting.AutoMapper
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
