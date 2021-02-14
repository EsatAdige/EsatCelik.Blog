using System;
using System.Collections.Generic;
using System.Text;

namespace EsatCelik.Blog.Entities.Concrete
{
    public class ArticleCategory : EntityBase<int>
    {
        public ArticleCategory()
        {
            
        }

        public ArticleCategory(int articleId, int categoryId)
        {
            this.ArticleId = articleId;
            this.CategoryId = categoryId;
        }

        public int? ArticleId { get; set; }

        public int? CategoryId { get; set; }

        public Article Article { get; set; }

        public Category Category { get; set; }
    }
}
