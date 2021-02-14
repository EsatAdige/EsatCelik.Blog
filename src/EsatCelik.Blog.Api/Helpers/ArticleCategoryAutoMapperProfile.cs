using AutoMapper;
using EsatCelik.Blog.Api.Dtos;
using EsatCelik.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsatCelik.Blog.Api.Helpers
{
    public class ArticleCategoryAutoMapperProfile : Profile
    {
        public ArticleCategoryAutoMapperProfile()
        {
            CreateMap<ArticleCategory, CategoryForListDto>()
                .ForMember(dest => dest.Id,
                    opt => { opt.MapFrom(src => src.Category.Id); })
                .ForMember(dest => dest.Name,
                    opt => { opt.MapFrom(src => src.Category.CategoryName); });
        }
    }
}
