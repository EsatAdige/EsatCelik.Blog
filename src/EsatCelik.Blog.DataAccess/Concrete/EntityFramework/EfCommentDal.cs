using EsatCelik.Blog.DataAccess.Abstract;
using EsatCelik.Blog.Entities.Concrete;
using EsatCelik.Core.DataAccess.EntityFramework;

namespace EsatCelik.Blog.DataAccess.Concrete.EntityFramework
{
    public class EfCommentDal : EfRepositoryBase<Comment, BlogContext>, ICommentDal
    {
        public EfCommentDal(BlogContext context) : base(context)
        {
        }
    }
}
