namespace ExcelReader.Mapper.Attributes
{
    /// <summary>
    /// Ensures the property value has a length within a specified range.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class StringLengthAttribute : Attribute
    {
        /// <summary>
        /// Gets the error message to be thrown if the length of the string validation fails.
        /// </summary>
        public string ErrorMessage { get; }
        /// <summary>
        /// Gets the minimum length of the string.
        /// </summary>
        public int MinimumLength { get; }

        /// <summary>
        /// Gets the maximum length of the string.
        /// </summary>
        public int MaximumLength { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringLengthAttribute"/> class.
        /// </summary>
        /// <param name="minimumLength">The minimum length of the string.</param>
        /// <param name="maximumLength">The maximum length of the string.</param>
        public StringLengthAttribute(int minimumLength, int maximumLength, string errorMessage)
        {
            MinimumLength = minimumLength;
            MaximumLength = maximumLength;
            ErrorMessage = errorMessage;
        }
    }
}
