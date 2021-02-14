using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EsatCelik.Blog.Api.Dtos;
using EsatCelik.Blog.Entities.Concrete;

namespace EsatCelik.Blog.Api.Helpers
{
    public class CategoryAutoMapperProfile : Profile
    {
        public CategoryAutoMapperProfile()
        {
            CreateMap<Category, CategoryForListDto>()
                .ForMember(dest => dest.Id,
                    opt => { opt.MapFrom(src => src.Id); })
                .ForMember(dest => dest.Name,
                    opt => { opt.MapFrom(src => src.CategoryName); });
        }
    }
}
