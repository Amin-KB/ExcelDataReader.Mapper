using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExcelReader.Mapper.ChecksAndValidations
{
    public delegate void ValidationDelegate(PropertyInfo prop, object value);
}
