using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EsatCelik.Blog.Business.Abstract;
using EsatCelik.Blog.DataAccess.Abstract;
using EsatCelik.Blog.Entities.Concrete;

namespace EsatCelik.Blog.Business.Concrete
{
    public class ArticleCategoryManager : IArticleCategoryService
    {
        private readonly IArticleCategoryDal _articleCategoryDal;

        public ArticleCategoryManager(IArticleCategoryDal articleCategoryDal)
        {
            _articleCategoryDal = articleCategoryDal;
        }

        public async Task<ArticleCategory> GetAsync(int articleId, int categoryId)
        {
            return await _articleCategoryDal.GetAsync(ac => ac.ArticleId == articleId && ac.CategoryId == categoryId);
        }

        public async Task<ArticleCategory> AddAsync(ArticleCategory articleCategory)
        {
            var newArticleCategory = await _articleCategoryDal.AddAsync(articleCategory);
            await _articleCategoryDal.CommitAsync();

            return newArticleCategory;
        }

        public async Task<ArticleCategory> UpdateAsync(ArticleCategory articleCategory)
        {
            var newArticleCategory = await _articleCategoryDal.UpdateAsync(articleCategory);
            await _articleCategoryDal.CommitAsync();

            return newArticleCategory;
        }

        public async Task DeleteAsync(int articleId, int categoryId)
        {
            var articleCategory = await _articleCategoryDal.GetAsync(ac => ac.ArticleId == articleId && ac.CategoryId == categoryId);

            await _articleCategoryDal.DeleteAsync(articleCategory);
            await _articleCategoryDal.CommitAsync();
        }
    }
}
