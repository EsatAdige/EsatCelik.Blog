using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using EsatCelik.Blog.Entities.Concrete;

namespace EsatCelik.Blog.Api.Models
{
    public class ArticleSaveModel
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "{0} RequiredErrorMessage")]
        [MaxLength(160, ErrorMessage = "{0} {1} MaxLengthErrorMessage")]
        public string Title { get; set; }

        [Display(Name = "Blog Address")]
        [Required(ErrorMessage = "{0} RequiredErrorMessage")]
        [MaxLength(120, ErrorMessage = "{0} {1} MaxLengthErrorMessage")]
        public string ArticleAddress { get; set; }

        [Display(Name = "Content")]
        public string Content { get; set; }

        [Display(Name = "Cover Photo")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        public int MainPictureResourceId { get; set; }

        public bool AllowComment { get; set; } = true;

        [Display(Name = "Cover Photo")]
        [ForeignKey("MainPictureResourceId")]
        public Resource MainPictureResource { get; set; }
    }
}
