using EsatCelik.Blog.DataAccess.Abstract;
using EsatCelik.Blog.Entities.Concrete;
using EsatCelik.Core.DataAccess.EntityFramework;

namespace EsatCelik.Blog.DataAccess.Concrete.EntityFramework
{
    public class EfResourceDal : EfRepositoryBase<Resource, BlogContext>, IResourceDal
    {
        public EfResourceDal(BlogContext context) : base(context)
        {
        }
    }
}
