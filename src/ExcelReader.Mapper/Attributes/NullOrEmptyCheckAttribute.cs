using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelReader.Mapper.Attributes
{

    /// <summary>
    /// Ensures the property value is not null or empty.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class NullOrEmptyCheckAttribute : Attribute
    {
        /// <summary>
        /// Gets the error message to be thrown if the check fails.
        /// </summary>
        public string ErrorMessage { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NullOrEmptyCheckAttribute"/> class.
        /// </summary>
        /// <param name="errorMessage">The error message to be thrown if the check fails.</param>
        public NullOrEmptyCheckAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
