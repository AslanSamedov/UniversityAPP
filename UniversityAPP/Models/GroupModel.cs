using Ejournall.Attributes;
using Ejournall.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Models
{
    public class GroupModel : BaseModel<GroupModel>
    {
        public string Name { get; set; }

        [ExcelIgnoreAttribute]
        public int SpecialityID{ get; set; }
        public SpecialityModel Speciality { get; set; }


        public override GroupModel Clone()
        {
            return new GroupModel()
            {
                Id = Id,
                No = No,    
                Name = Name,    
                Speciality = Speciality.Clone()
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
                message = ValidationHelper.GetRequiredMessage(Name);
                return false;
            }
            //if (string.IsNullOrWhiteSpace(SpecialityID.ToString()))
            //{
            //    message = ValidationHelper.GetRequiredMessage(SpecialityID.ToString());
            //    return false;
            //}

            message = string.Empty;
            return true;
        }
    }
}
