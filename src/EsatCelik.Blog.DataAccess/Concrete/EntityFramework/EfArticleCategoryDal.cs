using System;
using System.Collections.Generic;
using System.Text;
using EsatCelik.Blog.DataAccess.Abstract;
using EsatCelik.Blog.Entities.Concrete;
using EsatCelik.Core.DataAccess.EntityFramework;

namespace EsatCelik.Blog.DataAccess.Concrete.EntityFramework
{
    public class EfArticleCategoryDal : EfRepositoryBase<ArticleCategory, BlogContext>, IArticleCategoryDal
    {
        public EfArticleCategoryDal(BlogContext context) : base(context)
        {
        }
    }
}
