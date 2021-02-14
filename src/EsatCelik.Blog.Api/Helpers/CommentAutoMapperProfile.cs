using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EsatCelik.Blog.Api.Dtos;
using EsatCelik.Blog.Entities.Concrete;

namespace EsatCelik.Blog.Api.Helpers
{
    public class CommentAutoMapperProfile : Profile
    {
        public CommentAutoMapperProfile()
        {
            CreateMap<Comment, CommentForListDto>();
        }
    }
}
