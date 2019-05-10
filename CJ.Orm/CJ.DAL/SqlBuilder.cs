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

        /// <summary>
        /// 更新字符串
        /// </summary>
        private static string UpdateSql = null;

        static SqlBuilder()
        {
            Type type = typeof(T);

            InsertSql = $"INSERT INTO {type.GetMappingName()} ({string.Join(", ", type.GetPropertyWithoutKey().Select(p => $"{p.GetMappingName()}"))}) VALUES ({string.Join(", ", type.GetPropertyWithoutKey().Select(p => $"@{p.GetMappingName()}"))})";

            SelectOneSql = $"SELECT {string.Join(",", type.GetProperties().Select(p => $"[{p.GetMappingName()}]"))} FROM [{type.GetMappingName()}] WHERE [ID]=@Id";

            UpdateSql = $"UPDATE [dbo].[{type.GetMappingName()}] SET {string.Join(",", type.GetPropertyWithoutKey().Select(p => $"[{p.GetMappingName()}]=@{p.GetMappingName()}"))} WHERE [ID] = @Id";
        }

        public static string GetSql(SqlType sqlType)
        {
            switch (sqlType)
            {
                case SqlType.Insert:
                    return InsertSql;
                case SqlType.Select:
                    return SelectOneSql;
                case SqlType.Update:
                    return UpdateSql;
                default:
                    throw new Exception("SqlType Error");
            }
        }
    }

    
}
