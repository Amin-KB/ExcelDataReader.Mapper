using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExcelReader.Mapper.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EmailAttribute : ValidationAttribute
    {
        private const string EmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        private static readonly Regex EmailRegex = new Regex(EmailPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public string ErrorMessage { get; }
        public EmailAttribute(string errorMessage) : base(errorMessage)
        {
            ErrorMessage=errorMessage;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true; // Consider null as valid. Use [Required] attribute for null checks.
            }

            return value is string stringValue && EmailRegex.IsMatch(stringValue);
        }
    }
}
