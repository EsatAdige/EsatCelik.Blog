using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EsatCelik.Blog.Api.Models
{
    public class CategorySaveModel
    {
        public int Id { get; set; }

        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "{0} RequiredErrorMessage")]
        [MaxLength(60, ErrorMessage = "{0} {1} MaxLengthErrorMessage")]
        public string Name { get; set; }
    }
}
