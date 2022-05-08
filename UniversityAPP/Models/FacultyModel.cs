using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Models
{
    public class FacultyModel : BaseModel<FacultyModel>
    {
        public string Name { get; set; }    

        public override FacultyModel Clone()
        {
            return new FacultyModel()
            {
                No = No,
                Id = Id,
                Name = Name,
            };
        }

        public override string ExcelToString()
        {
            return Name;
        }

        public override bool IsValid(out string message)
        {
            throw new NotImplementedException();
        }
    }
}
