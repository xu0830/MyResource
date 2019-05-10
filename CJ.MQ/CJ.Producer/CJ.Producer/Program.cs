using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJ.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.UserName = "guest";
            factory.Password = "guest";

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello", false, false, false, null);
                    Console.WriteLine("read line");
                    int flag = 1;
                    while (flag != 0)
                    {
                        string message = Console.ReadLine();
                        int.TryParse(message, out flag);
                        var body = Encoding.UTF8.GetBytes(message);
                        channel.BasicPublish("", "hello", null, body);
                        Console.WriteLine(" set {0}", message);
                    }
                }
            }
        }
    }
}
