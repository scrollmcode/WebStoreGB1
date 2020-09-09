using System;
using System.Collections.Generic;
using System.Text;
using WebStoreGB1.Domain.Entities.Base;
using WebStoreGB1.Domain.Entities.Base.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStoreGB1.Domain.Entities
{
    [Table("Categories")]
    public class Category: NamedEntity, IOrderedEntity
    {
        public int? ParentId { get; set; }

        public int Order { get; set; }

        [ForeignKey("ParentId")]
        public virtual Category ParentCategory { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
