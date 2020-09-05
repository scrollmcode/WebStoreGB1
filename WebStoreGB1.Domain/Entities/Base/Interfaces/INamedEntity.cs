using System;
using System.Collections.Generic;
using System.Text;

namespace WebStoreGB1.Domain.Entities.Base.Interfaces
{
    public interface INamedEntity : IBaseEntity
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
