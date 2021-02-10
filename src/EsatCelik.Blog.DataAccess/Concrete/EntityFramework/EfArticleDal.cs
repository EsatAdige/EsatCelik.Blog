using EsatCelik.Blog.DataAccess.Abstract;
using EsatCelik.Blog.Entities.Concrete;
using EsatCelik.Core.DataAccess.EntityFramework;

namespace EsatCelik.Blog.DataAccess.Concrete.EntityFramework
{
    public class EfArticleDal : EfRepositoryBase<Article, BlogContext>, IArticleDal
    {
        public EfArticleDal(BlogContext context) : base(context)
        {

        }
    }
}
