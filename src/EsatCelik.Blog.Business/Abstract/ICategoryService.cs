using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EsatCelik.Blog.Entities.Concrete;

namespace EsatCelik.Blog.Business.Abstract
{
    public interface ICategoryService
    {
        Task<Category> GetByIdAsync(int id);

        Task<ICollection<Category>> GetListAsync(string categoryName = "");

        Task<Category> UpdateAsync(Category category);

        Task<Category> AddAsync(Category category);

        Task DeleteAsync(int id);
    }
}
