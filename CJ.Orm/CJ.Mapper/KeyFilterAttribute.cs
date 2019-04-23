
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJ.Mapper
{
    /// <summary>
    /// 主键过滤特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class KeyFilterAttribute:Attribute
    {

    }
}
