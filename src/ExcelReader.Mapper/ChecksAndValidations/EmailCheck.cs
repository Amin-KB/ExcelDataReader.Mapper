using ExcelReader.Mapper.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExcelReader.Mapper.ChecksAndValidations
{
    public static class EmailCheck
    {
        public static void Validate(PropertyInfo property, object value)
        {
            var emailAttribute = property.GetCustomAttribute<EmailAttribute>();
            if (emailAttribute != null && !emailAttribute.IsValid(value))
            {
                throw new ValidationException(emailAttribute.ErrorMessage);
            }
        }
    }
}
