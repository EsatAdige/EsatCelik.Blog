using System.Collections.Generic;
using System.Threading.Tasks;
using EsatCelik.Blog.Entities.Concrete;

namespace EsatCelik.Blog.Business.Abstract
{
    public interface ICommentService
    {
        Task<Comment> GetById(int id);

        Task<ICollection<Comment>> GetList();

        Task<ICollection<Comment>> GetListByArticleId(int articleId);

        Task<ICollection<Comment>> GetListByUserInformationId(int userInformationId);

        Task<Comment> Update(Comment comment);

        Task<Comment> Add(Comment comment);

        Task Delete(int id);
    }
}
