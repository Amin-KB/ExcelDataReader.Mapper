using ExcelReader.Mapper.Attributes;
using System.Reflection;

namespace ExcelReader.Mapper.ChecksAndValidations
{
    public static class CustomValidationCheck
    {
        public static void Validate(PropertyInfo prop, object value)
        {
            var attribute = prop.GetCustomAttribute<CustomValidationAttribute>();
            if (attribute != null && !attribute.IsValid(value))
            {
                throw new InvalidOperationException(attribute.ErrorMessage);
            }
        }
    }
}
