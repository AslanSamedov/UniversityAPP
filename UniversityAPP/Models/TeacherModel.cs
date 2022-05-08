using Ejournall.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Models
{
    public class TeacherModel : BaseModel<TeacherModel>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
        public int WorkExperience { get; set; }
     
        public override TeacherModel Clone()
        {
            return new TeacherModel()
            {
                Id = Id,
                Name = Name,
                Surname = Surname,
                BirthDate = BirthDate,
                WorkExperience = WorkExperience
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
            if (string.IsNullOrWhiteSpace(Surname))
            {
                message = ValidationHelper.GetRequiredMessage("Surname");
                return false;
            }
            if (WorkExperience < 0 || string.IsNullOrWhiteSpace(WorkExperience.ToString()))
            {
                message = ValidationHelper.GetRequiredMessage("WorkExperience");
                return false;
            }
            if (string.IsNullOrWhiteSpace(BirthDate.ToString()) || DateTime.TryParse(BirthDate.ToString(), out DateTime result) == false)
            {
                message = ValidationHelper.GetRequiredMessage("Birthdate");
                return false;
            }
            else if ((DateTime.Now.Year - DateTime.Parse(BirthDate).Year < 18))
            {
                message = "People under 18 cannot Work as Teacher at our University";
                return false;
            }
            else if ((DateTime.Now.Year - DateTime.Parse(BirthDate).Year > 70))
            {
                message = "People Elder Than 70 cannot Work as Teacher at our University";
                return false;
            }
            message = string.Empty;
            return true;
        }

    }
}
