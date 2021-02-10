using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EsatCelik.Blog.Entities.Concrete
{
    public class Tag : EntityBase<int>
    {
        [Display(Name = "Tag Name")]
        public string TagName { get; set; }
    }
}
