using CJ.DAL;
using CJ.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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

            var user = SqlHelper.Retrieve<User>(1033);
            user.Name = "尼玛wang";
            SqlHelper.Create(user);

            Directory.GetCurrentDirectory();

            Path.Combine();

            //HashMap

            Console.WriteLine();
        }
    }

    public class Test
    {
        public string Factor { get; set; }

        public Test()
        {
            this.Factor = "ddd";
        }

        public void FactorChange(string value)
        {
            this.Factor = value;
        }

        public void FactorChange(ref string value)
        {
            this.Factor = value;
        }

        public override string ToString()
        {
            return this.Factor;
        }
    }
}
