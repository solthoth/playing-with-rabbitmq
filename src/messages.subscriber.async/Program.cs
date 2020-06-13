using EasyNetQ;
using messages.core;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace messages.subscriber.async
{
    class Program
    {
        static void Main(string[] args)
        {
            const string rabbitConnectionString = "host=localhost;username=guest;password=guest";

            Console.WriteLine("Subscriber-async started...");
            using var bus = RabbitHutch.CreateBus(rabbitConnectionString);
            bus.SubscribeAsync<Notification>("Notification-Subscription",
                msg => GetNotification(msg));
        
            Console.Write("Listening for messages. Hit <return> to quit.");
            Console.ReadLine();
        }

        static Task GetNotification(Notification message)
        {
            var task = Task.Factory.StartNew(() => { Console.WriteLine(JsonConvert.SerializeObject(message)); });
            if (task.IsCompleted && !task.IsFaulted)
            {
                throw new EasyNetQException("Message processing exception - look in the default error queue (broker)");
            }
            return task;
        }
    }
}
