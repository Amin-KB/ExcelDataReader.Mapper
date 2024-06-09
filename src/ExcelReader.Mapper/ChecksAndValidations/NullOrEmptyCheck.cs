using ExcelReader.Mapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExcelReader.Mapper.ChecksAndValidations
{
    /// <summary>
    /// Provides validation to check if a property value is null or empty.
    /// </summary>
    public static class NullOrEmptyCheck
    {
        /// <summary>
        /// Validates that the property value is not null or empty.
        /// </summary>
        /// <param name="prop">The property to validate.</param>
        /// <param name="value">The value of the property.</param>
        public static void Validate(PropertyInfo prop, object value)
        {
            var attribute = prop.GetCustomAttribute<NullOrEmptyCheckAttribute>();
            if (attribute != null && (value == DBNull.Value || string.IsNullOrEmpty(value?.ToString())))
            {
                throw new InvalidOperationException(attribute.ErrorMessage);
            }
        }
    }
    public static class RangeCheck
    {
        public static void Validate(PropertyInfo prop, object value)
        {
            var attribute = prop.GetCustomAttribute<RangeAttribute>();
            if (attribute != null && double.TryParse(value?.ToString(), out double numericValue))
            {
                if (numericValue < attribute.Minimum || numericValue > attribute.Maximum)
                {
                    throw new InvalidOperationException($"{prop.Name} must be between {attribute.Minimum} and {attribute.Maximum}.");
                }
            }
        }
    }


    public static class StringLengthCheck
    {
        public static void Validate(PropertyInfo prop, object value)
        {
            var attribute = prop.GetCustomAttribute<StringLengthAttribute>();
            var valueAsString = value?.ToString();
            if (attribute != null && valueAsString != null)
            {
                if (valueAsString.Length < attribute.MinimumLength || valueAsString.Length > attribute.MaximumLength)
                {
                    throw new InvalidOperationException($"{prop.Name} length must be between {attribute.MinimumLength} and {attribute.MaximumLength}.");
                }
            }
        }
    }


    public static class FormatCheck
    {
        public static void Validate(PropertyInfo prop, object value)
        {
            var attribute = prop.GetCustomAttribute<FormatAttribute>();
            var valueAsString = value?.ToString();
            if (attribute != null && valueAsString != null && !attribute.IsValidFormat(valueAsString))
            {
                throw new InvalidOperationException($"{prop.Name} has an invalid format.");
            }
        }
    }

}
