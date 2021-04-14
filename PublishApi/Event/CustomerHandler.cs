using CoreFrameWork.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublishApi.Event
{
    public class CustomerHandler : IMessageHandler<CustomerEvent>
    {
        public Task HandAsync(CustomerEvent message)
        {
            Console.WriteLine(message.Id);
            return Task.CompletedTask;
        }
    }
}
