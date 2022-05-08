using Ejournall.Core.Entities;
using Ejournall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejournall.Utils;

namespace Ejournall.Mapper
{
    public class ExamMapper : BaseMapper<Exam, ExamModel>
    {
        private readonly LessonMapper lessonMapper = new LessonMapper();
        public override Exam Map(ExamModel model)
        {
            return new Exam()
            {
                Id = model.Id,
                EndTime = model.EndTime,
                StartTime = model.StartTime,
                ExamDate = model.ExamDate,
                Lesson = lessonMapper.Map(model.Lesson)
            };
        }

        public override ExamModel Map(Exam entity)
        {
            return new ExamModel() 
            {
                Id = entity.Id,
                StartTime = entity.StartTime,
                EndTime = entity.EndTime,
                ExamDate = entity.ExamDate,
                Lesson = lessonMapper.Map(entity.Lesson)
            };
        }
    }
}
