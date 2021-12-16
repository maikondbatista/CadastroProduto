using AutoMapper;
using Categories.Domain.Dtos;
using Categories.Domain.Entites;

namespace Categories.Infra.CrossCutting.AutoMapper
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, CategoryBaseDto>().ReverseMap();
        }
    }
}
