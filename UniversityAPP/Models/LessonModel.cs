using Ejournall.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Models
{
    public class LessonModel : BaseModel<LessonModel>
    {
        public GroupModel Group { get; set; }
        public TeacherSubjectModel Subject { get; set; }
        public SemesterModel Semester { get; set; }
        public ClassRoomModel Classroom { get; set; }

        public override LessonModel Clone()
        {
            return new LessonModel()
            {
                Id = Id,
                Group = Group.Clone(),
                Subject = Subject.Clone(),
                Semester = Semester.Clone(),
                Classroom = Classroom.Clone(),
            };
        }

        public override string ExcelToString()
        {
            string value = $"{Group.Name},{Subject.Subject.Name},{Semester.Name},{Classroom.ClassNo}";

            return value;   
        }

        public override bool IsValid(out string message)
        {
            if (Group == null)
            {
                message = ValidationHelper.GetRequiredMessage("Group");
                return false;
            }
            else if (Subject ==  null)
            {
                message = ValidationHelper.GetRequiredMessage("Subject");
                return false;
            }
            else if (Semester == null)
            {
                message = ValidationHelper.GetRequiredMessage("Semester");
                return false;
            }
            else if (Classroom == null)
            {
                message = ValidationHelper.GetRequiredMessage("Classroom");
                return false;
            }
            
            message = string.Empty;
            return true;

        }
    }
}
