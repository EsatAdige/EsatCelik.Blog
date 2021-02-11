using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EsatCelik.Blog.Entities.Concrete;

namespace EsatCelik.Blog.Business.Abstract
{
    public interface ITagService
    {
        Task<Tag> GetById(int id);

        Task<ICollection<Tag>> GetList(string name = "");

        Task<Tag> Update(Tag tag);

        Task<Tag> Add(Tag tag);

        Task Delete(int id);
    }
}
