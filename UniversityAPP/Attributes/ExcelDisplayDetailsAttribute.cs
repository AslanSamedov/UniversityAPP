using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Attributes
{
    public class ExcelDisplayDetailsAttribute : Attribute
    {
        public int ColumnNo { get; set; }
        public string Name { get; set; }
    }
}
