using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EsatCelik.Blog.Entities.Concrete
{
    public class Resource : EntityBase<int>
    {
        [Display(Name = "Material Name")]
        public string Name { get; set; }

        [Display(Name = "Url")]
        [Required(ErrorMessage = "{0} RequiredErrorMessage")]
        [MaxLength(120, ErrorMessage = "{0} {1} MaxLengthErrorMessage")]
        public string Url { get; set; }

        [Display(Name = "Thumbnail")]
        public string Thumbnail { get; set; }

        [Display(Name = "Content Type")]
        public string ContentType { get; set; } 
    }
}
