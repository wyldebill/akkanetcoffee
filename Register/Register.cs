using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Akka.Actor;
using Messages;

namespace MoonDollars
{
    public class Register : ReceiveActor
    {
        public  Register()
        {
            Receive<ChargeCoffee>(msg => ChargeCustomer(msg));
        }


        private void ChargeCustomer(ChargeCoffee msg)
        {
            
            Random rnd= new Random(DateTime.Now.Millisecond);
            int randomNumber = rnd.Next(10);

            if (randomNumber < 2)
            {
                Console.WriteLine($"REGISTER:: **FAILED Payment authorization for order {msg.OrderId}");
                Thread.Sleep(2000);
                Sender.Tell(false);
            }
            else
            {
                Console.WriteLine($"REGISTER:: SUCCESS Payment authorization for order {msg.OrderId}.");
                Thread.Sleep(2000);
                Sender.Tell(true);
            }
        }
    }
}
