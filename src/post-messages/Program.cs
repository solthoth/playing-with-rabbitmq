using System;

namespace post_messages
{
    class Program
    {
        static void Main(string[] args)
        {
            const string rabbitConnectionString = "host=localhost;username=guest;password=guest";
            Console.WriteLine("Hello World!");
            CreatePubSubMessageService(rabbitConnectionString).CreateMessages();
        }

        static PubSubMessageService CreatePubSubMessageService(string rabbitConnectionString)
        {
            return new PubSubMessageService(rabbitConnectionString);
        }
    }
}
