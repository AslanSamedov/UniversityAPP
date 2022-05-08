using Ejournall.Entities;
using Ejournall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Mapper
{
    public class TeacherSubjectMapper : BaseMapper<TeacherSubject, TeacherSubjectModel>
    {
        private readonly TeacherMapper teacherMapper = new TeacherMapper();
        private readonly SubjectMapper subjectMapper = new SubjectMapper();

        public override TeacherSubject Map(TeacherSubjectModel model)
        {
            return new TeacherSubject()
            {
                Id = model.Id,  
                Teacher = teacherMapper.Map(model.Teacher),
                Subject = subjectMapper.Map(model.Subject),
            };
        }

        public override TeacherSubjectModel Map(TeacherSubject entity)
        {
            return new TeacherSubjectModel()
            {
                Id= entity.Id,
                Subject = subjectMapper.Map(entity.Subject),
                Teacher = teacherMapper.Map(entity.Teacher),    
            };
        }
    }
}
