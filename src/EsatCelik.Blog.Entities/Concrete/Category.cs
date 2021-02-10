using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EsatCelik.Blog.Entities.Concrete
{
    public class Category : EntityBase<int>
    {
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
    }
}
