using Ejournall.Core.Entities;
using Ejournall.Entities;
using Ejournall.Models;

namespace Ejournall.Mapper
{
    public class StudentMapper : BaseMapper<Student, StudentModel>
    {
        private readonly GroupMapper groupMapper = new GroupMapper();
        public override StudentModel Map(Student student)
        {
            StudentModel stdModel = new StudentModel();
            stdModel.Id = student.Id;
            stdModel.Name = student.Name;
            stdModel.Surname = student.Surname;
            stdModel.Birthdate = student.Birthdate;
            stdModel.GroupId = student.GroupId;
            stdModel.Group = groupMapper.Map(student.Group);

            return stdModel;
        }

        public override Student Map(StudentModel studentModel)
        {
            Student student = new Student();
            student.Id = studentModel.Id;
            student.Name = studentModel.Name;
            student.Surname = studentModel.Surname;
            student.Birthdate = studentModel.Birthdate;
            student.GroupId = studentModel.GroupId;
            student.Group = groupMapper.Map(studentModel.Group);

            return student;
        }
    }
}
