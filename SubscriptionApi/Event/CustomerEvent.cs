using CoreFrameWork.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubscriptionApi.Event
{
    [MessageName("customer")]
    public class CustomerEvent : Message
    {
    }
}
