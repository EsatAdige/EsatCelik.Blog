using System.Collections.Generic;
using System.Threading.Tasks;
using EsatCelik.Blog.Entities.Concrete;

namespace EsatCelik.Blog.Business.Abstract
{
    public interface ICommentService
    {
        Task<Comment> GetByIdAsync(int id);

        Task<ICollection<Comment>> GetListAsync();

        Task<ICollection<Comment>> GetListByArticleIdAsync(int articleId);

        Task<ICollection<Comment>> GetListByUserInformationIdAsync(int userInformationId);

        Task<Comment> UpdateAsync(Comment comment);

        Task<Comment> AddAsync(Comment comment);

        Task DeleteAsync(int id);
    }
}
