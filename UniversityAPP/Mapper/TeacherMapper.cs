using Ejournall.Entities;
using Ejournall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Mapper
{
    public class TeacherMapper : BaseMapper<Teacher, TeacherModel>
    {
        public override TeacherModel Map(Teacher entity)
        {
            TeacherModel model = new TeacherModel();
            model.Id = entity.Id;
            model.Name = entity.Name;
            model.Surname = entity.Surname;
            model.BirthDate = entity.BirthDate;
            model.WorkExperience = entity.WorkExperience;

            return model;
        }

        public override Teacher Map(TeacherModel model)
        {
            Teacher teacher = new Teacher();
            teacher.Id = model.Id;
            teacher.Name = model.Name;
            teacher.Surname= model.Surname;
            teacher.BirthDate = model.BirthDate;
            teacher.WorkExperience= model.WorkExperience;   

            return teacher;
        }
    }
}
