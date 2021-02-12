using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EsatCelik.Blog.Entities.Concrete
{
    public class Category : EntityBase<int>
    {
        public Category()
        {
            
        }

        public Category(int id, string categoryName)
        {
            base.Id = id;
            this.CategoryName = categoryName;
        }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        public ICollection<ArticleCategory> ArticleCategories { get; set; }
    }
}
