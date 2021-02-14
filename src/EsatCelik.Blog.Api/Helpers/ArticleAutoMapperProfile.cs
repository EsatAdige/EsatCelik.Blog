using AutoMapper;
using EsatCelik.Blog.Api.Dtos;
using EsatCelik.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsatCelik.Blog.Api.Helpers
{
    public class ArticleAutoMapperProfile:Profile
    {
        public ArticleAutoMapperProfile()
        {
            CreateMap<Article, ArticleForListDto>()
                .ForMember(dest => dest.ResourceId,
                    opt => { opt.MapFrom(src => src.MainPictureResource.Id); })
                .ForMember(dest => dest.ResourceName,
                    opt => { opt.MapFrom(src => src.MainPictureResource.Name); })
                .ForMember(dest => dest.ResourceUrl,
                    opt => { opt.MapFrom(src => src.MainPictureResource.Url); })
                .ForMember(dest => dest.ResurceThumbnail,
                    opt => { opt.MapFrom(src => src.MainPictureResource.Thumbnail); })
                .ForMember(dest => dest.ResurceContentType,
                    opt => { opt.MapFrom(src => src.MainPictureResource.ContentType); })
                .ForMember(dest => dest.Comments,
                    opt => { opt.MapFrom(src => src.Comments); })
                .ForMember(dest => dest.Categories,
                    opt => { opt.MapFrom(src => src.ArticleCategories.Select(category => category )); });
        }
    }
}
