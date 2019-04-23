using CJ.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJ.DAL
{
    /// <summary>
    /// sql字符串缓存类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SqlBuilder<T>
    {
        /// <summary>
        /// 查询字符串
        /// </summary>
        private static string SelectOneSql = null;

        /// <summary>
        /// 插入字符串
        /// </summary>
        private static string InsertSql = null;

        static SqlBuilder()
        {
            Type type = typeof(T);

            SelectOneSql = $"INSERT INTO {type.GetMappingName()} ({string.Join(", ", type.GetPropertyWithoutKey().Select(p => $"{p.GetMappingName()}"))}) VALUES ({string.Join(", ", type.GetPropertyWithoutKey().Select(p => $"@{p.GetMappingName()}"))})";

            InsertSql = $"SELECT {string.Join(",", type.GetProperties().Select(p => $"[{p.GetMappingName()}]"))} FROM [{type.GetMappingName()}] WHERE [ID]=";
        }

        public static string GetSql(SqlType sqlType)
        {
            switch (sqlType)
            {
                case SqlType.Insert:
                    return SelectOneSql;
                case SqlType.Select:
                    return InsertSql;
                default:
                    throw new Exception("SqlType Error");
            }
        }
    }

    
}
