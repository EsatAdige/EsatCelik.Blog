using System;
using System.Collections.Generic;
using System.Text;

namespace EsatCelik.Blog.Entities.Concrete
{
    public class ArticleCategory : EntityBase<int>
    {
        public int? ArticleId { get; set; }

        public int? CategoryId { get; set; }

        public Article Article { get; set; }

        public Category Category { get; set; }
    }
}
