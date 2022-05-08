using Ejournall.Abstraction;
using Ejournall.Core.DataAccessLayer.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.DataAccessLayer.Abstraction
{
    public interface IUnitOfWork
    {
        IFacultyRepository FacultyRepository { get; }
        IGroupRepository GroupRepository { get; }
        ISemesterRepository SemesterRepository { get; }
        ISpecialityRepository SpecialityRepository { get; }
        IStudentRepository StudentRepository { get; }
        ISubjectRepository SubjectRepository { get; }
        ITeacherRepository TeacherRepository { get; }
        ICorpusRepository CorpusRepository { get; }
        ITeacherSubjectRepository TeacherSubjectRepository { get; }
        IUserRepository UserRepository { get; }
        ILessonRepository LessonRepository { get; }
        IClassRoomRepository ClassRoomRepository { get; }
        IExamRepository ExamRepository { get; }
        ILessonTimeRepository LessonTimeRepository { get; }

        IExamScoreRepository ExamScoreRepository { get; }
    }
}
