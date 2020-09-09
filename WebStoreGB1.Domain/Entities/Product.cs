using System;
using System.Collections.Generic;
using System.Text;
using WebStoreGB1.Domain.Entities.Base;
using WebStoreGB1.Domain.Entities.Base.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStoreGB1.Domain.Entities
{
    public class Product : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        public int CategoryId { get; set; }
        public int? BrandId { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }

        [ForeignKey("CategoryId")] // не обязательно в целом
        public virtual Category Category { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }
    }
}
