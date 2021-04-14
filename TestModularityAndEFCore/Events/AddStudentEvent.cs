using CoreFrameWork.Domain.Events;
using CoreFrameWork.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestModularityAndEFCore.Events
{
    [MessageName("customer")]
    public class AddStudentEvent : AggregateRootEvent
    {
        public string AggregateRootId { get; set; }
    }
}
