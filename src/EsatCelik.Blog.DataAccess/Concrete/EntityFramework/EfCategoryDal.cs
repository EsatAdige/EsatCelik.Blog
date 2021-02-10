using EsatCelik.Blog.DataAccess.Abstract;
using EsatCelik.Core.DataAccess.EntityFramework;

namespace EsatCelik.Blog.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfRepositoryBase<Entities.Concrete.Category, BlogContext>, ICategoryDal
    {
        public EfCategoryDal(BlogContext context) : base(context)
        {
        }
    }
}
