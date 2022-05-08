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
    public class LessonTimeMapper : BaseMapper<LessonTime, LessonTimeModel>
    {
        private readonly LessonMapper lessonMapper = new LessonMapper();
        public override LessonTime Map(LessonTimeModel model)
        {
            return new LessonTime()
            {
                Id = model.Id,
                EndTime = model.EndTime,
                StartTime = model.StartTime,
                Lesson = lessonMapper.Map(model.Lesson)
            };
        }

        public override LessonTimeModel Map(LessonTime entity)
        {
            return new LessonTimeModel()
            {
                Id = entity.Id,
                StartTime = entity.StartTime,
                EndTime = entity.EndTime,
                Lesson = lessonMapper.Map(entity.Lesson)
            };
        }
    }
}
