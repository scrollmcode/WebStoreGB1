using System;
using System.Collections.Generic;
using System.Text;
using WebStoreGB1.Domain.Entities.Base.Interfaces;

namespace WebStoreGB1.Domain.Entities.Base
{
    public class NamedEntity : INamedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
