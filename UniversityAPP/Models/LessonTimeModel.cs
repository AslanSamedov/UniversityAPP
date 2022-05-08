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
    public class LessonTimeModel : BaseModel<LessonTimeModel>
    {
        public LessonModel Lesson { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public override LessonTimeModel Clone()
        {
            return new LessonTimeModel()
            {
                Id = Id,
                No = No,
                Lesson = Lesson,
                StartTime = StartTime,
                EndTime = EndTime
            };
        }

        public override string ExcelToString()
        {
            return $"{Lesson.Subject.Subject.Name}  {StartTime.Date}";
        }

        public override bool IsValid(out string message)
        {
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
