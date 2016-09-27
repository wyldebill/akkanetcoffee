using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class ThanksForOrdering
    {
        public Guid OrderId { get; private set; }
        public ThanksForOrdering(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
