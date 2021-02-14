using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsatCelik.Blog.Api.Models
{
    public class ArticleCategorySaveModel
    {
        public int ArticleId { get; set; }

        public int CategoryId { get; set; }
    }
}
