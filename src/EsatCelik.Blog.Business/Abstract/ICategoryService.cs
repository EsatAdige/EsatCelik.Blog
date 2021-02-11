using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EsatCelik.Blog.Entities.Concrete;

namespace EsatCelik.Blog.Business.Abstract
{
    public interface ICategoryService
    {
        Task<Category> GetById(int id);

        Task<ICollection<Category>> GetList(string categoryName = "");

        Task<Category> Update(Category category);

        Task<Category> Add(Category category);

        Task Delete(int id);
    }
}
