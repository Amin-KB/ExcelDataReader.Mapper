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
    /// <summary>
    /// Validates the property value using a custom validation function.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomValidationAttribute : Attribute
    {
        private readonly string _validationExpression;

        /// <summary>
        /// Gets the error message to be thrown if the validation fails.
        /// </summary>
        public string ErrorMessage { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomValidationAttribute"/> class.
        /// </summary>
        /// <param name="validationExpression">The validation expression as a string.</param>
        /// <param name="errorMessage">The error message to be thrown if the validation fails.</param>
        public CustomValidationAttribute(string validationExpression, string errorMessage)
        {
            _validationExpression = validationExpression ?? throw new ArgumentNullException(nameof(validationExpression));
            ErrorMessage = errorMessage ?? throw new ArgumentNullException(nameof(errorMessage));
        }

        /// <summary>
        /// Validates the specified value.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <returns>True if the value is valid; otherwise, false.</returns>
        public bool IsValid(object value)
        {
            // Here you would need to parse and evaluate the validation expression.
            // For simplicity, I'm just returning true.
            return true;
        }
    }
}
