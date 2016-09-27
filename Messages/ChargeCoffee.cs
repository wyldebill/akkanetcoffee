using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class ChargeCoffee
    {
        public Guid OrderId { get; private set; }
        public ChargeCoffee(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
