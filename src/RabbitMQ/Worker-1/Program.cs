using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQClient;
using System;
using System.Text;

namespace Worker_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Fanout fanout = new Fanout();
            fanout.Comsume();
        }
    }
}
