using System;
using System.Collections.Generic;
using System.Text;

namespace EsatCelik.Blog.Entities.Concrete
{
    public class Comment : EntityBase<int>
    {
        public Comment()
        {
            
        }

        public Comment(int id, string title, string message, int articleId)
        {
            base.Id = id;
            this.Title = title;
            this.Message = message;
            this.ArticleId = articleId;
        }

        public string Title { get; set; }

        public string Message { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; }
    }
}
