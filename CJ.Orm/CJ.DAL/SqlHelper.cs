using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CJ.Mapper;

namespace CJ.DAL
{
    public class SqlHelper
    {
        private static string ConnectionStr = ConfigurationManager.AppSettings["connectionstring"];

        public static T Retrieve<T>(int Id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                Type type = typeof(T);
                string colStr = string.Join(",", type.GetProperties().Select(p => $"[{p.GetMappingName()}]"));

                string sqlStr = $@"SELECT {colStr}
                                  FROM [{type.GetMappingName()}]
                                  WHERE [ID] = {Id}";
                conn.Open();
                SqlCommand command = new SqlCommand(sqlStr, conn);
                var result = command.ExecuteReader();
                if (result.Read())
                {
                    T t = Activator.CreateInstance<T>();

                    foreach (var prop in type.GetProperties())
                    {
                        prop.SetValue(t, result[prop.GetMappingName()] is DBNull? null : result[prop.GetMappingName()]);
                    }

                    return t;
                }

                return default(T);
            }
        }
    }
}
