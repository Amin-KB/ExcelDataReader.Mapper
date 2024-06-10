using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExcelReader.Mapper.ChecksAndValidations
{
    public static class Validator
    {
        public static readonly List<ValidationDelegate> Validations = new List<ValidationDelegate>
    {
        NullOrEmptyCheck.Validate,
        RangeCheck.Validate,
        StringLengthCheck.Validate,
        FormatCheck.Validate,
        CustomValidationCheck.Validate,
        EmailCheck.Validate
    };

        public static object ApplyDefaultValue(PropertyInfo prop, object value)
        {
            return DefaultValueHandler.Apply(prop, value);
        }
    }
}
