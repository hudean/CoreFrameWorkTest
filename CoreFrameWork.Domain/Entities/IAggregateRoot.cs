using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFrameWork.Domain.Entities
{
    /// <summary>
    /// 聚合根接口
    /// </summary>
    public interface IAggregateRoot : IEntity
    {
    }

    /// <summary>
    /// 聚合根泛型接口
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IAggregateRoot<TKey> : IEntity<TKey>, IAggregateRoot
    {
    }
}
