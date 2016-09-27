using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class PaymentWasDeclined
    {
        public Guid OrderId { get; private set; }
        public PaymentWasDeclined(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
