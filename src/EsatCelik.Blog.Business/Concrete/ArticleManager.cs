using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EsatCelik.Blog.Business.Abstract;
using EsatCelik.Blog.DataAccess.Abstract;
using EsatCelik.Blog.Entities.Concrete;

namespace EsatCelik.Blog.Business.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public async Task<Article> GetById(int id)
        {
            return await _articleDal.GetAsync(x => x.Id == id);
        }

        public async Task<ICollection<Article>> GetList(string title = "", string content = "")
        {
            List<Expression<Func<Article, bool>>> filters = new List<Expression<Func<Article, bool>>>();
            
            if(!string.IsNullOrEmpty(title))
                filters.Add(article => article.Title.Contains(title));
            if (!string.IsNullOrEmpty(content))
                filters.Add(article => article.Content.Contains(content));


            return await _articleDal.GetListAsync(filters, x => x.OrderByDescending(x => x.InsertDate));
        }

        public async Task<ICollection<Article>> GetListByCategoryId(int categoryId)
        {
            List<Expression<Func<Article, bool>>> filters = new List<Expression<Func<Article, bool>>>();
            
            filters.Add(article => article.Categories.Where(category => category.Id == categoryId).Count() > 0);

            return await _articleDal.GetListAsync(filters, x => x.OrderByDescending(x => x.InsertDate));
        }

        public async Task<Article> Update(Article article)
        {
            var newArticle = await _articleDal.UpdateAsync(article);
            await _articleDal.CommitAsync();

            return newArticle;
        }

        public async Task<Article> Add(Article article)
        {
            var newArticle = await _articleDal.AddAsync(article);
            await _articleDal.CommitAsync();

            return newArticle;
        }

        public async Task Delete(int id)
        {
            var article = await _articleDal.GetAsync(x => x.Id == id);

            await _articleDal.DeleteAsync(article);
            await _articleDal.CommitAsync();
        }
    }
}
