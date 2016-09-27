using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Messages;


namespace MoonDollars
{
    public class Customer : ReceiveActor
    {
        public IActorRef TheBarista { get; set; }
        public Customer(IActorRef baristaRef)
        {
            // keep a reference to the barista actor
            TheBarista = baristaRef;

            // setup the handlers for the messages that this actor will recieve
            Receive<PaymentWasDeclined>(msg => OrderDeclinedHandler(msg));
            Receive<ThanksForOrdering>(msg => ThanksForOrderingHandler(msg));


            // kick things off
            IWantCoffee needCoffeeMessage = new IWantCoffee();
            
   /*         Context.System.Scheduler.ScheduleTellRepeatedly(TimeSpan.FromSeconds(10),
             TimeSpan.FromSeconds(2),
             TheBarista, 
             needCoffeeMessage, 
             Self);*/

            #region all messages at once
         /*    for (int z = 0; z < 3000; z++)
             {
                 baristaRef.Tell(needCoffeeMessage);
             }*/
            #endregion


        }

        public void OrderDeclinedHandler(PaymentWasDeclined msg)
        {
            Console.WriteLine($"CUSTOMER::   But I really need my coffee...Order: {msg.OrderId}");
            Thread.Sleep(3000);
        }

        public void ThanksForOrderingHandler(ThanksForOrdering msg)
        {
            Console.WriteLine($"CUSTOMER::   Mmmmmmm coffee!!! Order: {msg.OrderId}");
            Thread.Sleep(3000);
        }

        
    }
}
