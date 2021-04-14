using CoreFrameWork.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublishApi.Event
{
    [MessageName("customer")]
    public class CustomerEvent : Message
    {
    }
}
