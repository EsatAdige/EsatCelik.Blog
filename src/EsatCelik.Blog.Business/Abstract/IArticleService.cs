
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EsatCelik.Blog.Entities.Concrete;

namespace EsatCelik.Blog.Business.Abstract
{
    public interface IArticleService
    {
        Task<Article> GetByIdAsync(int id);

        Task<ICollection<Article>> GetListAsync(string title = "", string content = "");

        Task<ICollection<Article>> GetListByCategoryIdAsync(int categoryId);

        Task<Article> UpdateAsync(Article article);

        Task<Article> AddAsync(Article article);

        Task DeleteAsync(int id);
    }
}
