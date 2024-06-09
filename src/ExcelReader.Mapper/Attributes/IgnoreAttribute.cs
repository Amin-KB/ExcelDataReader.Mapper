namespace ExcelReader.Mapper.Attributes
{
    /// <summary>
    /// Indicates that the property should be ignored during the mapping process.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreAttribute : Attribute
    {
    }
}
