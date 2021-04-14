using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.Domain.Entities
{
    public class Entity : IEntity
    {
    }

    public class Entity<TKey> : Entity, IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
