using System;
using EasyNetQ;
using messages.core;
using Newtonsoft.Json;

namespace messages.subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            const string rabbitConnectionString = "host=localhost;username=guest;password=guest";
            
            Console.WriteLine("Subscriber started...");
            using var bus = RabbitHutch.CreateBus(rabbitConnectionString);
            bus.Subscribe<Notification>("Notification-Subscription",
                msg => Console.WriteLine(JsonConvert.SerializeObject(msg)));

            Console.Write("Listening for messages. Hit <return> to quit.");
            Console.ReadLine();
        }
    }
}
