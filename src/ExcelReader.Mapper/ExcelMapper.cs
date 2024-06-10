using ExcelDataReader;
using ExcelReader.Mapper.Attributes;
using ExcelReader.Mapper.ChecksAndValidations;
using System.Data;
using System.Reflection;
using System.Text;

namespace ExcelReader.Mapper;

public class ExcelMapper
{

    public static void RegisterEncodingProvider()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }
    private static string GetTableName<T>()
    {
        var tableNameAttribute = typeof(T).GetCustomAttribute<ExcelTableAttribute>();

        if (tableNameAttribute == null)
        {
            throw new InvalidOperationException("The class must have an ExcelTable attribute specifying the sheet name.");
        }

        return tableNameAttribute.TableName;
    }

    private static DataTable GetDataTable(string filePath, string tableName)
    {
        using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        {
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });

                var dataTable = result.Tables.Cast<DataTable>().FirstOrDefault(t => t.TableName == tableName);

                if (dataTable == null)
                {
                    throw new InvalidOperationException($"The sheet '{tableName}' does not exist in the Excel file.");
                }

                return dataTable;
            }
        }
    }
    //private static List<T> MapRowsToClass<T>(DataTable dataTable) where T : new()
    //{
    //    var rows = new List<T>();

    //    foreach (DataRow dataRow in dataTable.Rows)
    //    {
    //        var rowObject = new T();
    //        foreach (var prop in typeof(T).GetProperties())
    //        {
    //            var attribute = prop.GetCustomAttribute<ExcelColumnAttribute>();
    //            var nullOrEmptyCheckAttribute = prop.GetCustomAttribute<NullOrEmptyCheckAttribute>();

    //            if (attribute != null)
    //            {
    //                var value = dataRow[attribute.ColumnIndex];
    //                if (nullOrEmptyCheckAttribute != null && (value == DBNull.Value || string.IsNullOrEmpty(value?.ToString())))
    //                {
    //                    throw new InvalidOperationException(nullOrEmptyCheckAttribute.ErrorMessage);
    //                }

    //                if (value != DBNull.Value)
    //                {
    //                    prop.SetValue(rowObject, Convert.ChangeType(value, prop.PropertyType));
    //                }
    //            }
    //        }
    //        rows.Add(rowObject);
    //    }

    //    return rows;
    //}


    private static List<T> MapRowsToClass<T>(DataTable dataTable) where T : new()
    {
        var rows = new List<T>();

        foreach (DataRow dataRow in dataTable.Rows)
        {
            var rowObject = new T();
            foreach (var prop in typeof(T).GetProperties())
            {
                if (prop.GetCustomAttribute<IgnoreAttribute>() != null)
                {
                    continue;  // Skip properties with IgnoreAttribute
                }

                var columnAttribute = prop.GetCustomAttribute<ExcelColumnAttribute>();
                if (columnAttribute == null)
                {
                    continue;
                }

                var value = dataRow[columnAttribute.ColumnIndex];

                // Apply default value if needed
                value = Validator.ApplyDefaultValue(prop, value);

                // Perform validations
                foreach (var validation in Validator.Validations)
                {
                    validation(prop, value);
                }
                if (value != DBNull.Value)
                {
                    var targetType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                    var convertedValue = Convert.ChangeType(value, targetType);
                    prop.SetValue(rowObject, convertedValue);
                }
                else if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    prop.SetValue(rowObject, null);
                }
                //if (value != DBNull.Value)
                //{
                //    prop.SetValue(rowObject, Convert.ChangeType(value, prop.PropertyType));
                //}
            }
            rows.Add(rowObject);
        }

        return rows;
    }


    public static List<T> Map<T>(string filePath) where T : new()
    {
        // Register the encoding provider
        RegisterEncodingProvider();

        // Get the table name from the attribute
        var tableName = GetTableName<T>();

        // Get the data table from the Excel file
        var dataTable = GetDataTable(filePath, tableName);

        // Map the data table rows to the class
        var rows = MapRowsToClass<T>(dataTable);

        return rows;
    }
}
