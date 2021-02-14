using EsatCelik.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsatCelik.Blog.Api.Dtos
{
    public class ArticleForListDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string BlogAddress { get; set; }

        public string Content { get; set; }

        public int MainPictureResourceId { get; set; }

        public bool AllowComment { get; set; } = true;

        #region Resource
        public string ResourceId { get; set; }

        public string ResourceName { get; set; }

        public string ResourceUrl { get; set; }

        public string ResurceThumbnail { get; set; }

        public string ResurceContentType { get; set; }
        #endregion

        public ICollection<CommentForListDto> Comments { get; set; }

        public ICollection<CategoryForListDto> Categories { get; set; }
    }
}
