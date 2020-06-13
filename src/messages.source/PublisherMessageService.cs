using System;
using System.Threading;
using EasyNetQ;
using messages.core;

namespace messages.source
{
    public class PublisherMessageService
    {
        private readonly string ConnectionString;
        public PublisherMessageService(string connectionString)
        {
            ConnectionString = connectionString;
        }
        internal void CreateMessages()
        {
            using (var bus = RabbitHutch.CreateBus(ConnectionString))
            {
                for (int i = 0; i < 10; i++)
                {
                    bus.Publish(new Notification
                    {
                        QueueType = $"PubSub-{i}",
                        Message = $"HelloWorld {DateTime.Now}"
                    });
                    Thread.Sleep(500);
                }
            }
        }
    }
}