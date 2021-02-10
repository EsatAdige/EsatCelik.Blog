using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EsatCelik.Blog.Entities.Concrete
{
    public class UserInformation : EntityBase<int>
    {
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        public string Surname { get; set; }
    }
}
