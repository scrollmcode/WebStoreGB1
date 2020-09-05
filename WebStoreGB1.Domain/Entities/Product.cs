using System;
using System.Collections.Generic;
using System.Text;
using WebStoreGB1.Domain.Entities.Base;
using WebStoreGB1.Domain.Entities.Base.Interfaces;

namespace WebStoreGB1.Domain.Entities
{
    public class Product : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        public int CategoryId { get; set; }
        public int? BrandId { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
