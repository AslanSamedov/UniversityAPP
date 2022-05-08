using Ejournall.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Models
{
    public abstract class BaseModel <T>
    {
        [ExcelIgnoreAttribute]
        public int Id { get; set; } 

        [ExcelDisplayDetails(ColumnNo = 0, Name = "No")]
        public int No { get; set; }
        public abstract T Clone();
        public abstract bool IsValid(out string message);

        public abstract string ExcelToString();

    }

}
