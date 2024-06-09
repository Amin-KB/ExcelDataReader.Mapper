namespace ExcelReader.Mapper.Attributes
{
    /// <summary>
    /// Ensures the property value is within a specified range.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class RangeAttribute : Attribute
    {
        /// <summary>
        /// Gets the error message to be thrown if the range validation fails.
        /// </summary>
        public string ErrorMessage { get; }
        /// <summary>
        /// Gets the minimum value of the range.
        /// </summary>
        public double Minimum { get; }

        /// <summary>
        /// Gets the maximum value of the range.
        /// </summary>
        public double Maximum { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RangeAttribute"/> class.
        /// </summary>
        /// <param name="minimum">The minimum value of the range.</param>
        /// <param name="maximum">The maximum value of the range.</param>
        public RangeAttribute(double minimum, double maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomRangeAttribute"/> class with the specified minimum and maximum values.
        /// </summary>
        /// <param name="minimum">The minimum value allowed.</param>
        /// <param name="maximum">The maximum value allowed.</param>
        /// <param name="errorMessage">The error message to be thrown if the range validation fails.</param>
        public RangeAttribute(int minimum, int maximum, string errorMessage) 
        {
            Minimum = minimum;
            Maximum = maximum;
            ErrorMessage = errorMessage;
        }
    }
}
