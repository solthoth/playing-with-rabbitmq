using System;

namespace messages.source
{
    class Program
    {
        static void Main(string[] args)
        {
            const string rabbitConnectionString = "host=localhost;publisherConfirms=true;timeout=10;username=guest;password=guest";
            Console.WriteLine("Hello World!");
            CreatePubSubMessageService(rabbitConnectionString).CreateMessages();
        }

        static PublisherMessageService CreatePubSubMessageService(string rabbitConnectionString)
        {
            return new PublisherMessageService(rabbitConnectionString);
        }
    }
}
