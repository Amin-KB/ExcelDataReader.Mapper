using ExcelReader.Mapper.Attributes;
using System.Reflection;

namespace ExcelReader.Mapper.ChecksAndValidations
{
    /// <summary>
    /// Provides a mechanism to apply a default value if the property value is null or empty.
    /// </summary>
    public static class DefaultValueHandler
    {
        /// <summary>
        /// Applies a default value to the property if the value is null or empty.
        /// </summary>
        /// <param name="prop">The property to apply the default value to.</param>
        /// <param name="value">The current value of the property.</param>
        /// <returns>The new value for the property.</returns>
        public static object Apply(PropertyInfo prop, object value)
        {
            var attribute = prop.GetCustomAttribute<DefaultValueAttribute>();
            if (attribute != null && (value == DBNull.Value || value == null))
            {
                return attribute.DefaultValue;
            }
            return value;
        }
    }
}
