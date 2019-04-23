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
        /// <summary>
        /// App.config中的数据库连接字符串
        /// </summary>
        private static string ConnectionStr = ConfigurationManager.AppSettings["connectionstring"];

        /// <summary>
        /// 数据插入
        /// 需要注意
        ///     1、字段空值判断
        ///     2、主键过滤
        ///     3、参数化查询防sql注入
        ///     4、字段映射
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool Create<T>(T t)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                Type type = typeof(T);
                conn.Open();
                SqlCommand command = new SqlCommand(SqlBuilder<T>.GetSql(SqlType.Insert), conn);

                IEnumerable<SqlParameter> sqlParameters = type.GetPropertyWithoutKey()
                    .Select(p => new SqlParameter($"{p.GetMappingName()}", p.GetValue(t) ?? DBNull.Value));
                command.Parameters.AddRange(sqlParameters.ToArray());

                int row = command.ExecuteNonQuery();

                return row == 1;
            }
        }

        /// <summary>
        /// 数据查询
        /// 需要注意
        ///     1、字段空值判断
        ///     2、字段映射
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static T Retrieve<T>(int Id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                Type type = typeof(T);
                conn.Open();
                SqlCommand command = new SqlCommand($"{SqlBuilder<T>.GetSql(SqlType.Select)}{Id}", conn);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    T t = Activator.CreateInstance<T>();

                    foreach (var prop in type.GetProperties())
                    {
                        prop.SetValue(t, reader[prop.GetMappingName()] is DBNull? null : reader[prop.GetMappingName()]);
                    }

                    return t;
                }
                reader.Close();
                return default(T);
            }
        }


    }
}
