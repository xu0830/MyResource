using CJ.DAL;
using CJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CJ.Orm
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(System.Environment.CurrentDirectory + "\\App.config");
            //System.Timers.Timer myTimer = new System.Timers.Timer(1000);
            ////TaskAction.SetContent表示要调用的方法
            //myTimer.Elapsed += new System.Timers.ElapsedEventHandler((object source, ElapsedEventArgs e) => {
            //    Console.WriteLine("定时器执行");
            //});
            //myTimer.Enabled = true;
            //myTimer.AutoReset = true;

            User user = SqlHelper.Retrieve<User>(12);

            Console.ReadLine();
        }
    }
}
