using Ejournall.Core.Entities;
using Ejournall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Mapper
{
    public class LessonMapper : BaseMapper<Lesson, LessonModel>
    {
        private readonly GroupMapper groupMapper = new GroupMapper();
        private readonly TeacherSubjectMapper teacherSubjectMapper = new TeacherSubjectMapper();    
        private readonly SemesterMapper semesterMapper = new SemesterMapper();
        private readonly ClassRoomMapper classRoomMapper = new ClassRoomMapper();

        public override Lesson Map(LessonModel model)
        {
            return new Lesson()
            {
                Id = model.Id,  
                Group = groupMapper.Map(model.Group),
                Subject = teacherSubjectMapper.Map(model.Subject),
                Semester = semesterMapper.Map(model.Semester),
                Classroom = classRoomMapper.Map(model.Classroom)
            };
        }

        public override LessonModel Map(Lesson entity)
        {
            return new LessonModel()
            {
                Id = entity.Id,
                Group = groupMapper.Map(entity.Group),
                Subject = teacherSubjectMapper.Map(entity.Subject),
                Semester = semesterMapper.Map(entity.Semester),
                Classroom = classRoomMapper.Map(entity.Classroom),
            };
        }
    }
}
