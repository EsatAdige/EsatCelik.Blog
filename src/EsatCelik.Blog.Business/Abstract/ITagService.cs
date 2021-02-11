using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EsatCelik.Blog.Entities.Concrete;

namespace EsatCelik.Blog.Business.Abstract
{
    public interface ITagService
    {
        Task<Tag> GetByIdAsync(int id);

        Task<ICollection<Tag>> GetListAsync(string name = "");

        Task<Tag> UpdateAsync(Tag tag);

        Task<Tag> AddAsync(Tag tag);

        Task DeleteAsync(int id);
    }
}
