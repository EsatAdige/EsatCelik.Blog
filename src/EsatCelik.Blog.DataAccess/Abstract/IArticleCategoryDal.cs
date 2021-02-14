using EsatCelik.Blog.Entities.Concrete;
using EsatCelik.Core.DataAccess;

namespace EsatCelik.Blog.DataAccess.Abstract
{
    public interface IArticleCategoryDal : IEntityRepository<ArticleCategory>
    {
    }
}
