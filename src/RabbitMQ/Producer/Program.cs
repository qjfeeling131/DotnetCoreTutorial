using RabbitMQ.Client;
using RabbitMQClient;
using System;
using System.Text;

namespace Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Fanout fanout = new Fanout();
            //fanout.Publish(args);

            Direct direct = new Direct();
            direct.Publish(args);
        }
    
    }
}
