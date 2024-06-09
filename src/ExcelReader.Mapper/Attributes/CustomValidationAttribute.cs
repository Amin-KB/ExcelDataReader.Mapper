namespace ExcelReader.Mapper.Attributes
{
    ///// <summary>
    ///// Validates the property value using a custom validation function.
    ///// </summary>
    //[AttributeUsage(AttributeTargets.Property)]
    //public class CustomValidationAttribute : Attribute
    //{
    //    private readonly Func<object, bool> _isValid;

    //    /// <summary>
    //    /// Gets the error message to be thrown if the validation fails.
    //    /// </summary>
    //    public string ErrorMessage { get; }

    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="CustomValidationAttribute"/> class.
    //    /// </summary>
    //    /// <param name="isValid">The validation function to validate the value.</param>
    //    /// <param name="errorMessage">The error message to be thrown if the validation fails.</param>
    //    public CustomValidationAttribute(Func<object, bool> isValid, string errorMessage)
    //    {
    //        _isValid = isValid;
    //        ErrorMessage = errorMessage;
    //    }

    //    /// <summary>
    //    /// Validates the specified value.
    //    /// </summary>
    //    /// <param name="value">The value to validate.</param>
    //    /// <returns>True if the value is valid; otherwise, false.</returns>
    //    public bool IsValid(object value) => _isValid(value);
    //}

    /// <summary>
    /// Validates the property value using a custom validation function.
    /// </summary>
    /// <summary>
    /// Validates the property value using a custom validation function.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomValidationAttribute : Attribute
    {
        private readonly string _validationMethodName;

        /// <summary>
        /// Gets the error message to be thrown if the validation fails.
        /// </summary>
        public string ErrorMessage { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomValidationAttribute"/> class.
        /// </summary>
        /// <param name="validationMethodName">The name of the validation method.</param>
        /// <param name="errorMessage">The error message to be thrown if the validation fails.</param>
        public CustomValidationAttribute(string validationMethodName, string errorMessage)
        {
            _validationMethodName = validationMethodName ?? throw new ArgumentNullException(nameof(validationMethodName));
            ErrorMessage = errorMessage ?? throw new ArgumentNullException(nameof(errorMessage));
        }

        /// <summary>
        /// Validates the specified value using the specified validation method.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <returns>True if the value is valid; otherwise, false.</returns>
        public bool IsValid(object value)
        {
            // Retrieve the method with the specified name from the containing class
            var method = GetType().GetMethod(_validationMethodName, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
            if (method == null)
            {
                throw new InvalidOperationException($"Method {_validationMethodName} not found.");
            }

            // Invoke the method and return the result
            return (bool)method.Invoke(this, new[] { value });
        }
    }
}
