using Ejournall.Abstraction;
using Ejournall.Core.DataAccessLayer.Abstraction;
using Ejournall.Core.DataAccessLayer.Implementation.SqlServer;
using Ejournall.DataAccessLayer.Abstraction;
using Ejournall.DataAccessLayer.SqlServer;
using Ejournall.DataAccessLayer.SqlServer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Core.DataAccessLayer.SqlServer.Repositories
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly string connectionString;

        public SqlUnitOfWork(string connectionString)
        {
            this.connectionString = connectionString;   
        }


        public IFacultyRepository FacultyRepository => new SqlFacultyRepository(connectionString);

        public IGroupRepository GroupRepository => new SqlGroupRepostiory(connectionString);

        public ISemesterRepository SemesterRepository => new SqlSemesterRepository(connectionString);

        public ISpecialityRepository SpecialityRepository => new SqlSpecialityRepository(connectionString);

        public IStudentRepository StudentRepository => new SqlStudentRepository(connectionString);

        public ISubjectRepository SubjectRepository => new SqlSubjectRepository(connectionString);  

        public ITeacherRepository TeacherRepository => new SqlTeacherRepository(connectionString);

        public ITeacherSubjectRepository TeacherSubjectRepository => new SqlTeachersSubjectRepositroy(connectionString);

        public IUserRepository UserRepository => new SqlUserRepository(connectionString);

        public ICorpusRepository CorpusRepository => new SqlCorpusRepository(connectionString);

        public IClassRoomRepository ClassRoomRepository => new SqlClassRoomRepository(connectionString);

        public ILessonRepository LessonRepository => new SqlLessonRepository(connectionString);

        public ILessonTimeRepository LessonTimeRepository => new SqlLessonTimesRepository(connectionString);
        public IExamRepository ExamRepository => new SqlExamRepository(connectionString);
        public IExamScoreRepository ExamScoreRepository => new SqlExamScoreRepository(connectionString);    
    }
}
