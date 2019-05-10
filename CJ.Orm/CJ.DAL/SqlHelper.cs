using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CJ.Mapper;
using CJ.Models;

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
            Type type = typeof(T);

            IEnumerable<SqlParameter> sqlParameters = type.GetPropertyWithoutKey()
                .Select(p => new SqlParameter($"{p.GetMappingName()}", p.GetValue(t) ?? DBNull.Value));

            return ExecuteSql(SqlBuilder<T>.GetSql(SqlType.Insert), sqlParameters, command => {
                return command.ExecuteNonQuery() == 1;
            });
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
            Type type = typeof(T);
            IEnumerable<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter($"@Id", Id)
            };

            return ExecuteSql($"{SqlBuilder<T>.GetSql(SqlType.Select)}", sqlParameters, command => {
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    T t = Activator.CreateInstance<T>();

                    foreach (var prop in type.GetProperties())
                    {
                        prop.SetValue(t, reader[prop.GetMappingName()] is DBNull ? null : reader[prop.GetMappingName()]);
                    }
                    return t;
                }
                return default(T);
            });
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool Update<T>(T t) where T : IEntity
        {
            Type type = typeof(T);
            IEnumerable<SqlParameter> sqlParameters = type.GetProperties()
                .Select(p => new SqlParameter($"{p.GetMappingName()}", p.GetValue(t) ?? DBNull.Value));
            return ExecuteSql(SqlBuilder<T>.GetSql(SqlType.Update), sqlParameters, command => {
                return command.ExecuteNonQuery() == 1;
            });
        }

        /// <summary>
        /// 执行sql
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="paraList"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        private static T ExecuteSql<T>(string sql, IEnumerable<SqlParameter> paraList, Func<SqlCommand, T> func)
        {
            SqlTransaction tran = null;
            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                try
                {
                    conn.Open();
                    tran = conn.BeginTransaction();
                    SqlCommand command = new SqlCommand(sql, conn);
                    command.Transaction = tran;
                    command.Parameters.AddRange(paraList.ToArray());
                    var result = func.Invoke(command);
                    tran.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return default(T);
                }
                finally
                {
                    if(tran != null)
                        tran.Dispose();
                }
            }
        }
    }
}
