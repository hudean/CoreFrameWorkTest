using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreFrameWork.EventBus
{
    /// <summary>
    /// 消息名称特性标签
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class MessageNameAttribute : Attribute
    {
        public virtual string Name { get; }

        public MessageNameAttribute(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"{nameof(name)} can not be null, empty or white space!");
            }
            Name = name;
        }

        public static string GetNameOrDefault(Type messageType)
        {
            if (messageType == null)
            {
                throw new ArgumentNullException(nameof(messageType));
            }
            return messageType
                       .GetCustomAttributes(true)
                       .OfType<MessageNameAttribute>()
                       .FirstOrDefault()
                       ?.Name
                   ?? messageType.FullName;
        }
    }
}
