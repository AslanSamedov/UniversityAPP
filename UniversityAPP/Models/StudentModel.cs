using Ejournall.Attributes;
using Ejournall.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Models
{
    public class StudentModel : BaseModel<StudentModel>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthdate { get; set; }
        public GroupModel Group { get; set; }

        [ExcelIgnoreAttribute]
        public int GroupId { get; set; }

        public override string ExcelToString()
        {
            return Name;
        }
        public override StudentModel Clone()
        {
            return new StudentModel()
            {
                Id = Id,
                No = No,
                Name = Name,
                Surname = Surname,
                Birthdate = Birthdate,
                GroupId = GroupId,
                Group = Group.Clone() as GroupModel
            };
        }
        public override bool IsValid(out string message)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                message = ValidationHelper.GetRequiredMessage("Name");
                return false;
            }
            if (string.IsNullOrWhiteSpace(Surname))
            {
                message = ValidationHelper.GetRequiredMessage("Surname");
                return false;
            }
            if (string.IsNullOrWhiteSpace(Birthdate.ToString()) || DateTime.TryParse(Birthdate.ToString(),out DateTime result) == false)
            {
                message = ValidationHelper.GetRequiredMessage("Birthdate");
                return false;
            }
            else if((DateTime.Now.Year - DateTime.Parse(Birthdate).Year < 18))
            {
                message = "People under 18 cannot study at our University";
                return false;
            }
            if (string.IsNullOrWhiteSpace(Group.Name))
            {
                message = ValidationHelper.GetRequiredMessage("Group");
                return false;
            }
            

            message = string.Empty;
            return true;
        }
    }
}
