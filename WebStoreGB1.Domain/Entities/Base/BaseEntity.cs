using System;
using System.Collections.Generic;
using System.Text;
using WebStoreGB1.Domain.Entities.Base.Interfaces;

namespace WebStoreGB1.Domain.Entities.Base
{
    public abstract class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
    }
}
