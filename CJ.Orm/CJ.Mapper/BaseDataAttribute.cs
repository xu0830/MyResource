using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJ.Mapper
{
    public abstract class BaseDataAttribute : Attribute
    {
        private string _Name { get; set; }

        public BaseDataAttribute(string name)
        {
            _Name = name;
        }

        public string GetName()
        {
            return this._Name;
        }
    }
}
