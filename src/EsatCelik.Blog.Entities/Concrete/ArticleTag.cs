using System;
using System.Collections.Generic;
using System.Text;

namespace EsatCelik.Blog.Entities.Concrete
{
    public class ArticleTag : EntityBase<int>
    {
        public int? ArticleId { get; set; }

        public int? TagId { get; set; }

        public Article Article { get; set; }

        public Tag Tag { get; set; }
    }
}
