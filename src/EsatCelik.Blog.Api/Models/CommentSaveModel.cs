using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsatCelik.Blog.Api.Models
{
    public class CommentSaveModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public int ArticleId { get; set; }
    }
}
