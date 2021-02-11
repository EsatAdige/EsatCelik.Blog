
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EsatCelik.Blog.Entities.Concrete;

namespace EsatCelik.Blog.Business.Abstract
{
    public interface IArticleService
    {
        Task<Article> GetById(int id);

        Task<ICollection<Article>> GetList(string title = "", string content = "");

        Task<ICollection<Article>> GetListByCategoryId(int categoryId);

        Task<Article> Update(Article article);

        Task<Article> Add(Article article);

        Task Delete(int id);
    }
}
