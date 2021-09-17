using RabbitMQClient;
using System;

namespace Worker_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Direct direct = new Direct();

            direct.Comsume(args);
        }
    }
}
