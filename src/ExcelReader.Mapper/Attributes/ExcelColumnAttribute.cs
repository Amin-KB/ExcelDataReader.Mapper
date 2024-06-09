using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelReader.Mapper.Attributes
{
    /// <summary>
    /// Specifies the column index in the Excel file for a property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ExcelColumnAttribute : Attribute
    {
        /// <summary>
        /// Gets the column index in the Excel file.
        /// </summary>
        public int ColumnIndex { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelColumnAttribute"/> class.
        /// </summary>
        /// <param name="columnIndex">The column index in the Excel file.</param>
        public ExcelColumnAttribute(int columnIndex)
        {
            ColumnIndex = columnIndex;
        }
    }
}
