using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EsatCelik.Blog.Entities.Concrete;

namespace EsatCelik.Blog.Business.Abstract
{
    public interface IResourceService
    {
        Task<Resource> GetById(int id);

        Task<ICollection<Resource>> GetList(string name = "");

        Task<Resource> Update(Resource comment);

        Task<Resource> Add(Resource comment);

        Task Delete(int id);
    }
}
