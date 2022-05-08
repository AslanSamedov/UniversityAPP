using Ejournall.Attributes;
using Ejournall.Core.Entities;
using Ejournall.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Models
{
    public class ExamModel : BaseModel<ExamModel>
    {
        public LessonModel Lesson { get; set; }
        public DateTime ExamDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime{ get; set; }

        public override ExamModel Clone()
        {
            return new ExamModel()
            {
                Id = Id,    
                No = No,
                Lesson = Lesson,
                ExamDate = ExamDate,    
                StartTime = StartTime,
                EndTime = EndTime
            };
        }

        public override string ExcelToString()
        {
            return $"{Lesson.Subject.Subject.Name}  {ExamDate.Date}";
        }

        public override bool IsValid(out string message)
        {
            if (string.IsNullOrWhiteSpace(ExamDate.ToString()))
            {
                message = ValidationHelper.GetRequiredMessage("ExamDate");
                return false;
            }
            if (string.IsNullOrWhiteSpace(StartTime.ToString()))
            {
                message = ValidationHelper.GetRequiredMessage("StartTime");
                return false;
            }
            if (string.IsNullOrWhiteSpace(EndTime.ToString()))
            {
                message = ValidationHelper.GetRequiredMessage("EndTime");
                return false;
            }
            //if (string.IsNullOrWhiteSpace(Lesson.Subject.Subject.Name))
            //{
            //    message = ValidationHelper.GetRequiredMessage("Subject");
            //    return false;
            //}

            message = string.Empty;
            return true;
        }
       
    }
}
