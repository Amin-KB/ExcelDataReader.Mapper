using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelReader.Mapper.Attributes
{
    /// <summary>
    /// Attribute to specify that a property can be null.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class NullableAttribute : Attribute
    {
        public bool IsNullable { get; }

        public NullableAttribute(bool isNullable = true)
        {
            IsNullable = isNullable;
        }
    }
}
