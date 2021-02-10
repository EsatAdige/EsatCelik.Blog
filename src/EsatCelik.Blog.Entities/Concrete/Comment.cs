using System;
using System.Collections.Generic;
using System.Text;

namespace EsatCelik.Blog.Entities.Concrete
{
    public class Comment : EntityBase<int>
    {
        public string Title { get; set; }

        public string Message { get; set; }

        public int BlogId { get; set; }

        public Blog Blog { get; set; }
    }
}
