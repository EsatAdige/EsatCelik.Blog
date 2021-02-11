using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EsatCelik.Blog.Entities.Concrete;

namespace EsatCelik.Blog.Business.Abstract
{
    public interface IResourceService
    {
        Task<Resource> GetByIdAsync(int id);

        Task<ICollection<Resource>> GetListAsync(string name = "");

        Task<Resource> UpdateAsync(Resource comment);

        Task<Resource> AddAsync(Resource comment);

        Task DeleteAsync(int id);
    }
}
