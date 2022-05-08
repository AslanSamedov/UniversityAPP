using Ejournall.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Models
{
    public class TeacherSubjectModel : BaseModel<TeacherSubjectModel>
    {
        public TeacherModel Teacher { get; set; }
        public SubjectModel Subject { get; set; }

        public override TeacherSubjectModel Clone()
        {
            return new TeacherSubjectModel()
            {
                Id = this.Id,
                Teacher = Teacher.Clone(),
                Subject = Subject.Clone()
            };
        }

        public override string ExcelToString()
        {
            string value = $"Teacher:{Teacher.Name} Subject:{Subject.Name}";
            return value;   
        }

        public override bool IsValid(out string message)
        {
            if (string.IsNullOrWhiteSpace(Subject.Name))
            {
                message = ValidationHelper.GetRequiredMessage("Subject");
                return false;
            }

            message = string.Empty;

            return true;

        }
    }
    
}

