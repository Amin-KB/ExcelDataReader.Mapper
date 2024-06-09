using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelReader.Mapper.Attributes
{
    /// <summary>
    /// Specifies the sheet name in the Excel file for a class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ExcelTableAttribute : Attribute
    {
        /// <summary>
        /// Gets the sheet name in the Excel file.
        /// </summary>
        public string TableName { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelTableAttribute"/> class.
        /// </summary>
        /// <param name="tableName">The sheet name in the Excel file.</param>
        public ExcelTableAttribute(string tableName)
        {
            TableName = tableName;
        }
    }
}
