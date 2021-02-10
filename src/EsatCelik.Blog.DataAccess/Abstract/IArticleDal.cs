using EsatCelik.Core.DataAccess;
using EsatCelik.Blog.Entities.Concrete;

namespace EsatCelik.Blog.DataAccess.Abstract
{
    public interface IArticleDal : IEntityRepository<Article>
    {
    }
}
