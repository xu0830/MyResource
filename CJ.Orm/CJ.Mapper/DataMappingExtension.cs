using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CJ.Mapper
{
    public static class DataMappingExtension
    {
        public static string GetMappingName<T>(this T type) where T : MemberInfo
        {
            if (type.IsDefined(typeof(BaseDataAttribute), true))
            {
                BaseDataAttribute baseDataAttribute = (BaseDataAttribute)type.GetCustomAttribute(typeof(BaseDataAttribute), true);
                return baseDataAttribute.GetName();
            }

            return type.Name;
        }
    }
}
