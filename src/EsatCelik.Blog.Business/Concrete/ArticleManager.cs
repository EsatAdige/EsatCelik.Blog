﻿using System;
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

        public async Task<Article> GetByIdAsync(int id)
        {
            return await _articleDal.GetAsync(x => x.Id == id, "MainPictureResource,Comments,ArticleCategories,ArticleCategories.Category");
        }

        public async Task<ICollection<Article>> GetListAsync(string title = "", string content = "")
        {
            List<Expression<Func<Article, bool>>> filters = new List<Expression<Func<Article, bool>>>();
            
            if(!string.IsNullOrEmpty(title))
                filters.Add(article => article.Title.Contains(title));
            if (!string.IsNullOrEmpty(content))
                filters.Add(article => article.Content.Contains(content));


            return await _articleDal.GetListAsync(filters, x => x.OrderByDescending(x => x.InsertDate), "MainPictureResource,Comments,ArticleCategories,ArticleCategories.Category");
        }

        public async Task<ICollection<Article>> GetListByCategoryIdAsync(int categoryId)
        {
            List<Expression<Func<Article, bool>>> filters = new List<Expression<Func<Article, bool>>>();
            
            filters.Add(article => article.ArticleCategories.Where(category => category.CategoryId == categoryId).Count() > 0);

            return await _articleDal.GetListAsync(filters, x => x.OrderByDescending(x => x.InsertDate), "MainPictureResource,Comments,ArticleCategories,ArticleCategories.Category");
        }

        public async Task<Article> UpdateAsync(Article article)
        {
            var newArticle = await _articleDal.UpdateAsync(article);
            await _articleDal.CommitAsync();

            return newArticle;
        }

        public async Task<Article> AddAsync(Article article)
        {
            var newArticle = await _articleDal.AddAsync(article);
            await _articleDal.CommitAsync();

            return newArticle;
        }

        public async Task DeleteAsync(int id)
        {
            var article = await _articleDal.GetAsync(x => x.Id == id, "ArticleCategories");
            foreach (var articleCategory in article.ArticleCategories)
            {
                articleCategory.Article = null;
            }

            await _articleDal.DeleteAsync(article);
            await _articleDal.CommitAsync();
        }
    }
}
