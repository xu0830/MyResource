﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJ.Mapper
{
    /// <summary>
    /// 数据库字段映射特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : BaseDataAttribute
    {
        public ColumnAttribute(string name): base(name)
        {

        }
    }
}
