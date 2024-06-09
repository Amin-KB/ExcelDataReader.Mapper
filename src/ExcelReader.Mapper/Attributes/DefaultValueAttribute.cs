using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelReader.Mapper.Attributes
{

    /// <summary>
    /// Sets a default value if the property value is null or empty.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DefaultValueAttribute : Attribute
    {
        /// <summary>
        /// Gets the default value to be set.
        /// </summary>
        public object DefaultValue { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultValueAttribute"/> class.
        /// </summary>
        /// <param name="defaultValue">The default value to be set.</param>
        public DefaultValueAttribute(object defaultValue)
        {
            DefaultValue = defaultValue;
        }
    }
}
