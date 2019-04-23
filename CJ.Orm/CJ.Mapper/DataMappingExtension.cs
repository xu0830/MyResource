using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CJ.Mapper
{
    /// <summary>
    /// 映射扩展类
    /// </summary>
    public static class DataMappingExtension
    {
        /// <summary>
        /// 获取实体类对应数据库的映射名称
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetMappingName<T>(this T type) where T : MemberInfo
        {
            if (type.IsDefined(typeof(BaseDataAttribute), true))
            {
                BaseDataAttribute baseDataAttribute = (BaseDataAttribute)type.GetCustomAttribute(typeof(BaseDataAttribute), true);
                return baseDataAttribute.GetName();
            }

            return type.Name;
        }

        /// <summary>
        /// 过滤实体类中的主键属性
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> GetPropertyWithoutKey(this Type type)
        {
            return type.GetProperties().Where(p => !p.IsDefined(typeof(KeyFilterAttribute), true));
        }
    }
}
