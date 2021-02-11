using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EsatCelik.Blog.Business.Abstract;
using EsatCelik.Blog.DataAccess.Abstract;
using EsatCelik.Blog.Entities.Concrete;

namespace EsatCelik.Blog.Business.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            return await _commentDal.GetAsync(x => x.Id == id);
        }

        public async Task<ICollection<Comment>> GetListAsync()
        {
            return await _commentDal.GetListAsync(null, x => x.OrderByDescending(x => x.InsertDate));
        }

        public async Task<ICollection<Comment>> GetListByArticleIdAsync(int articleId)
        {
            List<Expression<Func<Comment, bool>>> filters = new List<Expression<Func<Comment, bool>>>();

            filters.Add(comment => comment.ArticleId == articleId);

            return await _commentDal.GetListAsync(filters, x => x.OrderByDescending(x => x.InsertDate));
        }

        public async Task<ICollection<Comment>> GetListByUserInformationIdAsync(int userInformationId)
        {
            List<Expression<Func<Comment, bool>>> filters = new List<Expression<Func<Comment, bool>>>();

            filters.Add(comment => comment.InsertedBy == userInformationId);

            return await _commentDal.GetListAsync(filters, x => x.OrderByDescending(x => x.InsertDate));
        }

        public async Task<Comment> UpdateAsync(Comment comment)
        {
            var newComment = await _commentDal.UpdateAsync(comment);
            await _commentDal.CommitAsync();

            return newComment;
        }

        public async Task<Comment> AddAsync(Comment comment)
        {
            var newComment = await _commentDal.AddAsync(comment);
            await _commentDal.CommitAsync();

            return newComment;
        }

        public async Task DeleteAsync(int id)
        {
            var comment = await _commentDal.GetAsync(x => x.Id == id);

            await _commentDal.DeleteAsync(comment);
            await _commentDal.CommitAsync();
        }
    }
}
