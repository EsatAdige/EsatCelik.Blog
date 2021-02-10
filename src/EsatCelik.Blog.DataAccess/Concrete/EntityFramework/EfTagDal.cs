using EsatCelik.Blog.DataAccess.Abstract;
using EsatCelik.Blog.Entities.Concrete;
using EsatCelik.Core.DataAccess.EntityFramework;

namespace EsatCelik.Blog.DataAccess.Concrete.EntityFramework
{
    public class EfTagDal : EfRepositoryBase<Tag, BlogContext>, ITagDal
    {
        public EfTagDal(BlogContext context) : base(context)
        {
        }
    }
}
