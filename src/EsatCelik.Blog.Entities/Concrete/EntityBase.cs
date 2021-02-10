using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EsatCelik.Blog.Entities.Concrete
{
    public class EntityBase<TIdentity>
    {
        [Key]
        [DisplayName("Id")]
        public virtual TIdentity Id { get; set; }

        public DateTime InsertDate { get; set; } = DateTime.Now;

        public int InsertedBy { get; set; }

        [ForeignKey("InsertedBy")]
        public UserInformation InsertedUserInformation { get; set; }
    }
}
