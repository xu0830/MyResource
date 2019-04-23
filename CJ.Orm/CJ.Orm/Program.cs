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

            using (SqlConnection conn = new SqlConnection("Data Source=127.0.0.1; Initial Catalog=db_Test; User Id=sa; Password=TZ@2017")) {
                conn.Open();
                SqlCommand command = new SqlCommand("", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "proc_user";
                SqlParameter[] parms = {
                    new SqlParameter("@p1", 1034),
                    new SqlParameter("@p2", 1035)
                };
                var result = command.ExecuteNonQuery();
                
            }

            Directory.GetCurrentDirectory();

            Path.Combine();

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
