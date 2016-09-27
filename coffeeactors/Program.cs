using Akka.Actor;
using MoonDollars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MoonDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            // the actor system, everything lives in here
            ActorSystem system = ActorSystem.Create("CoffeeSystem");

            // the actors are created next. but not using the 'new' operator
            IActorRef theBarista = system.ActorOf(Props.Create<Barista>(), "Barista");
            IActorRef theRegister = system.ActorOf(Props.Create<Register>(), "Register");
            IActorRef theCustomer = system.ActorOf(Props.Create<Customer>(theBarista), "Jim");

            // just so the console program doesn't exit right away
            Console.ReadLine();

        }
    }
}
