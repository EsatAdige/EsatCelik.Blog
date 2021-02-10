using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EsatCelik.Blog.Entities.Concrete
{
    public class Article : EntityBase<int>
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage = "{0} RequiredErrorMessage")]
        [MaxLength(160, ErrorMessage = "{0} {1} MaxLengthErrorMessage")]
        public string Title { get; set; }

        [Display(Name = "Blog Address")]
        [Required(ErrorMessage = "{0} RequiredErrorMessage")]
        [MaxLength(120, ErrorMessage = "{0} {1} MaxLengthErrorMessage")]
        public string BlogAddress { get; set; }

        [Display(Name = "Content")]
        public string Content { get; set; }

        public int MainPictureResourceId { get; set; }

        public bool AllowComment { get; set; } = true;

        [ForeignKey("MainPictureResourceId")]
        public Resource MainPictureResource { get; set; }

        public ICollection<Resource> Resources { get; set; }

        public ICollection<Tag> Tags { get; set; }
        
        public ICollection<Category> Categories { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
