using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJ.Console
{
    class Program
    {
        static RedisClient redisClient = new RedisClient("47.107.143.99", 6379, "xucanjie");//redis服务IP和端口

        static void Main(string[] args)
        {
            System.Console.WriteLine(redisClient.Get<string>("city"));
            System.Console.ReadKey();
        }
    }
}
