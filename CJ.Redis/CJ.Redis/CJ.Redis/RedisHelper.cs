using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJ.Redis
{
    public class RedisHelper
    {
        static RedisClient redisClient = new RedisClient("47.107.143.99", 6379, "xucanjie");//redis服务IP和端口
    }
}
