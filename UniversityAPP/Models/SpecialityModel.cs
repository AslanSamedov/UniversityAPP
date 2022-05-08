using Ejournall.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Models
{
    public class SpecialityModel : BaseModel<SpecialityModel>
    {
        public string Name { get; set; }
        public FacultyModel Faculty { get; set; }

        public override SpecialityModel Clone()
        {
            return new SpecialityModel()
            {
                No = No,
                Id = Id,
                Name = Name,
                Faculty = Faculty.Clone() as FacultyModel,  
            };
        }

        public override string ExcelToString()
        {
            return Name;
        }

        public override bool IsValid(out string message)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                message = ValidationHelper.GetRequiredMessage("Name");
                return false;
            }
            //if (string.IsNullOrWhiteSpace(Faculty.Name))
            //{
            //    message = ValidationHelper.GetRequiredMessage("Faculty");
            //    return false;
            //}

            message = string.Empty;
            return true;
        }
    }
}
