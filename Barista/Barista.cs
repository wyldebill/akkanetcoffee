using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Messages;

namespace MoonDollars
{
    public class Barista : ReceiveActor
    {
        public Barista()
        {
            // setup the handlers for the messages that this actor will recieve
            Receive<IWantCoffee>(msg => IwantCoffeeHandler(msg));
        }

        private void IwantCoffeeHandler(IWantCoffee msg)
        {
            Console.WriteLine();

            Guid orderId = Guid.NewGuid();
            Console.WriteLine($"BARISTA::  Creating order {orderId} for coffee, checking payment authorization...");
            Thread.Sleep(2000);

            // check for payment with the register
            // this is a synchronous interaction, but it will only wait 10 seconds and then timeout.
            // and roughly 20% of the time the register will return false, payment wasn't accepted.
            bool moneyRecieved = Context.ActorSelection("akka://CoffeeSystem/user/Register").Ask<bool>(new ChargeCoffee(orderId), TimeSpan.FromSeconds(10)).Result;

            
            if (moneyRecieved)
            {
                Console.WriteLine($"BARISTA:: Preparing coffee for order # {orderId} ...");
                Thread.Sleep(2000);

                Console.WriteLine($"BARISTA:: Coffee is ready for order # {orderId}");
                Thread.Sleep(2000);

                Sender.Tell(new ThanksForOrdering(orderId));
            }
            else
            {
                Console.WriteLine($"BARISTA:: Sorry, payment for order {orderId} was declined.");
                Thread.Sleep(2000);

                Sender.Tell(new PaymentWasDeclined(orderId));

            }
        }

      
    }
}
