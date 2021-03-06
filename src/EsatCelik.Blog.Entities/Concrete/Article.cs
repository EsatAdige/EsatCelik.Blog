﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace EsatCelik.Blog.Entities.Concrete
{
    public class Article : EntityBase<int>
    {
        public Article()
        {
            
        }

        public Article(int id, string title, string articleAddress, string content, int mainPictureResourceId, bool allowComment, Resource resource)
        {
            this.Id = id;
            this.Title = title;
            this.ArticleAddress = articleAddress;
            this.Content = content;
            this.MainPictureResourceId = mainPictureResourceId;
            this.AllowComment = allowComment;
            this.MainPictureResource = resource;
            this.Comments = new List<Comment>();
        }

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
        
        public ICollection<ArticleCategory> ArticleCategories { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
