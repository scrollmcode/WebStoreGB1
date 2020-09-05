using System;
using System.Collections.Generic;
using System.Text;
using WebStoreGB1.Domain.Entities.Base;
using WebStoreGB1.Domain.Entities.Base.Interfaces;

namespace WebStoreGB1.Domain.Entities
{
    public class Category: NamedEntity, IOrderedEntity
    {
        public int? ParentId { get; set; }

        public int Order { get; set; }
    }
}
