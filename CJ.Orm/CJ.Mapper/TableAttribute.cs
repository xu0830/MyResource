using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJ.Mapper
{
    /// <summary>
    /// 数据库表映射特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : BaseDataAttribute
    {
        public TableAttribute(string name) : base(name)
        {

        }
    }
}
