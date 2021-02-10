using System;
using System.Collections.Generic;
using System.Text;

namespace EsatCelik.Blog.Entities.Concrete
{
    public class Comment : EntityBase<int>
    {
        public string Title { get; set; }

        public string Message { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; }
    }
}
