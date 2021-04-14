using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.Domain.Entities
{
    public interface IEntity
    {
    }

    public interface IEntity<TKey> : IEntity
    {
        TKey Id { get; set; }
    }
}
