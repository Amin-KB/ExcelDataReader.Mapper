# ExcelDataReader.Mapper

ExcelDataReader.Mapper is a library for mapping Excel sheets to C# classes with various validation and formatting attributes. This library leverages ExcelDataReader to read Excel files and provides an easy and declarative way to handle Excel data in C#.

## Features

- Map Excel sheets to C# classes using attributes.
- Validate data with custom validation, format checks, and email validation.
- Apply default values and check for null or empty values.

## Usage

1.  Define Your Model

```c#
[ExcelTable("Sheet1")]
public class ExcelRow
{
    [ExcelColumn(0)]
    [Custom("value => value.ToString().StartsWith(\"A\")", "Name must start with 'A'")]
    public string Name { get; set; }

    [ExcelColumn(1)]
    [Email("Invalid email format")]
    public string Email { get; set; }

    [ExcelColumn(2)]
    [Range(18, 65, "Age must be between 18 and 65")]
    public int Age { get; set; }

    [ExcelColumn(3)]
    [StringLength(10, "Phone number must be 10 digits long")]
    public string Phone { get; set; }

    [ExcelColumn(4)]
    [NullOrEmpty("Address cannot be null or empty")]
    public string Address { get; set; }
}
```

2.  Read Data from Excel

```c#
string filePath = "path/to/your/excel/file.xlsx";
var rows = ExcelMapper.Map<ExcelRow>(filePath);

  foreach (var row in rows)
        {
            Console.WriteLine($"{row.Name}, {row.Email}, {row.Age}, {row.Phone}, {row.Address}");
        }
```
