using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EsatCelik.Blog.Entities.Concrete;

namespace EsatCelik.Blog.Business.Abstract
{
    public interface IArticleCategoryService
    {
        Task<ArticleCategory> GetAsync(int articleId, int categoryId);

        Task<ArticleCategory> AddAsync(ArticleCategory articleCategory);

        Task<ArticleCategory> UpdateAsync(ArticleCategory articleCategory);
        
        Task DeleteAsync(int articleId, int categoryId);
    }
}
