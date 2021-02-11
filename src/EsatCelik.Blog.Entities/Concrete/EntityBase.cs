using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EsatCelik.Core.Entities;

namespace EsatCelik.Blog.Entities.Concrete
{
    public class EntityBase<TIdentity> : IEntity
    {
        [Key]
        [DisplayName("Id")]
        public virtual TIdentity Id { get; set; }

        public DateTime InsertDate { get; set; } = DateTime.Now;

        public int InsertedBy { get; set; }
    }
}
