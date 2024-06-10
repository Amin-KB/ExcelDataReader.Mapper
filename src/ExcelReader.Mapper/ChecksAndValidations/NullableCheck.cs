using System.Reflection;
using ExcelReader.Mapper.Attributes;

namespace ExcelReader.Mapper.ChecksAndValidations
{
    public static class NullableCheck
    {
        public static void Validate(PropertyInfo prop, object value)
        {
            var attribute = prop.GetCustomAttribute<NullableAttribute>();
            if (attribute != null && !attribute.IsNullable && value == null)
            {
                throw new InvalidOperationException($"{prop.Name} cannot be null.");
            }
        }
    }
}
