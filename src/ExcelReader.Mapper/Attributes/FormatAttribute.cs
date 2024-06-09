using System.Text.RegularExpressions;

namespace ExcelReader.Mapper.Attributes
{
    ///// <summary>
    ///// Validates the format of the property value using a custom validation function.
    ///// </summary>
    //[AttributeUsage(AttributeTargets.Property)]
    //public class FormatAttribute : Attribute
    //{
    //    private readonly Func<string, bool> _isValid;

    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="FormatAttribute"/> class.
    //    /// </summary>
    //    /// <param name="isValid">The validation function to validate the format.</param>
    //    public FormatAttribute(Func<string, bool> isValid)
    //    {
    //        _isValid = isValid;
    //    }

    //    /// <summary>
    //    /// Validates the format of the specified value.
    //    /// </summary>
    //    /// <param name="value">The value to validate.</param>
    //    /// <returns>True if the value is valid; otherwise, false.</returns>
    //    public bool IsValid(string value) => _isValid(value);
    //}

    /// <summary>
    /// Validates the property value using a custom format function.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class FormatAttribute : Attribute
    {
        private readonly string _formatMethodName;

        /// <summary>
        /// Gets the error message to be thrown if the format validation fails.
        /// </summary>
        public string ErrorMessage { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormatAttribute"/> class.
        /// </summary>
        /// <param name="formatMethodName">The name of the format validation method.</param>
        /// <param name="errorMessage">The error message to be thrown if the format validation fails.</param>
        public FormatAttribute(string formatMethodName, string errorMessage)
        {
            _formatMethodName = formatMethodName ?? throw new ArgumentNullException(nameof(formatMethodName));
            ErrorMessage = errorMessage ?? throw new ArgumentNullException(nameof(errorMessage));
        }

        /// <summary>
        /// Validates the specified value using the specified format validation method.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <returns>True if the value has the correct format; otherwise, false.</returns>
        public bool IsValidFormat(object value)
        {
            // Retrieve the method with the specified name from the containing class
            var method = GetType().GetMethod(_formatMethodName, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if (method == null)
            {
                throw new InvalidOperationException($"Method {_formatMethodName} not found.");
            }

            // Invoke the method and return the result
            return (bool)method.Invoke(this, new[] { value });
        }
    }
}
