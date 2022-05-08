using Ejournall.Core.Entities;
using Ejournall.DataAccessLayer.Abstraction;
using Ejournall.Entities;
using Ejournall.Mapper;
using Ejournall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.DataContext
{
    public class DataProvider
    {
        private readonly IUnitOfWork DB;

        public DataProvider(IUnitOfWork DB)
        {
            this.DB = DB;
        }

        public List<StudentModel> GetStudents()
        {
            var students = Kernel.DB.StudentRepository.GetAll();
            var models = new List<StudentModel>();

            StudentMapper mapper = new StudentMapper();

            for (int i = 0; i < students.Count; i++)
            {
                var model = students[i];
                var studentModel = mapper.Map(model);
                studentModel.No = i + 1;

                models.Add(studentModel);
            }
            return models;
        }
        public List<TeacherModel> GetTeachers()
        {
            var teacherEntity = Kernel.DB.TeacherRepository.GetAll();
            var models = new List<TeacherModel>();

            TeacherMapper mapper = new TeacherMapper();

            for (int i = 0; i < teacherEntity.Count; i++)
            {
                var entity = teacherEntity[i];
                var teacherModel = mapper.Map(entity);
                teacherModel.No = i + 1;

                models.Add(teacherModel);
            }
            return models;
        }
        public List<SubjectModel> GetSubjects()
        {
            var subjectEntitiesList = Kernel.DB.SubjectRepository.GetAll();
            var models = new List<SubjectModel>();

            SubjectMapper mapper = new SubjectMapper();

            for (int i = 0; i < subjectEntitiesList.Count; i++)
            {
                var entity = subjectEntitiesList[i];
                var model = mapper.Map(entity);
                model.No = i + 1;

                models.Add(model);
            }

            return models;
        }
        public List<GroupModel> GetGroups()
        {
            var groupEntity = Kernel.DB.GroupRepository.GetAll();
            var models = new List<GroupModel>();

            GroupMapper mapper = new GroupMapper();

            for (int i = 0; i < groupEntity.Count; i++)
            {
                var entity = groupEntity[i];
                var groupModel = mapper.Map(entity);
                groupModel.No = i + 1;
                models.Add(groupModel);
            }
            return models;
        }
        public List<SpecialityModel> GetSpecialties()
        {
            var specialityEntityies = Kernel.DB.SpecialityRepository.GetAll();
            var models = new List<SpecialityModel>();

            SpecialityMapper mapper = new SpecialityMapper();

            for (int i = 0; i < specialityEntityies.Count; i++)
            {
                var entity = specialityEntityies[i];
                var model = mapper.Map(entity);
                model.No = i + 1;

                models.Add(model);
            }
            return models;
        }
        public List<SemesterModel> GetSemesters()
        {
            var semesterEntityList = Kernel.DB.SemesterRepository.GetAll();
            var models = new List<SemesterModel>();

            SemesterMapper mapper = new SemesterMapper();

            for (int i = 0; i < semesterEntityList.Count; i++)
            {
                var entity = semesterEntityList[i];
                var model = mapper.Map(entity);
                model.No = i + 1;

                models.Add(model);
            }
            return models;
        }
        public List<CorpusModel> GetCorpuses()
        {
            var corpusEntitesList = Kernel.DB.CorpusRepository.GetAll();
            var models = new List<CorpusModel>();

            CorpusMapper mapper = new CorpusMapper();
            for (int i = 0; i < corpusEntitesList.Count; i++)
            {
                var entity = corpusEntitesList[i];
                var model = mapper.Map(entity);
                model.No = i + 1;

                models.Add(model);
            }
            return models;
        }
        public List<FacultyModel> GetFaculties()
        {
            var facultyEntities = Kernel.DB.FacultyRepository.GetAll();
            var models = new List<FacultyModel>();

            FacultyMapper mapper = new FacultyMapper();
            for (int i = 0; i < facultyEntities.Count; i++)
            {
                var entity = facultyEntities[i];
                var model = mapper.Map(entity);
                model.No = i + 1;

                models.Add(model);
            }
            return models;
        }
        public List<LessonModel> GetLessons()
        {
            var lessons = Kernel.DB.LessonRepository.GetAll();
            var models = new List<LessonModel>();

            LessonMapper mapper = new LessonMapper();
            for (int i = 0; i < lessons.Count; i++)
            {
                var entity = lessons[i];
                var model = mapper.Map(entity);
                model.No = i + 1;

                models.Add(model);
            }
            return models;
        }
        public List<ExamModel> GetExams()
        {
            var exams = Kernel.DB.ExamRepository.GetAll();
            var models = new List<ExamModel>();

            ExamMapper mapper = new ExamMapper();

            for (int i = 0; i < exams.Count; i++)
            {
                var entity = exams[i];
                var model = mapper.Map(entity);
                model.No = i + 1;

                models.Add(model);
            }
            return models;
        }
        public List<LessonTimeModel> GetLessonTimes()
        {
            var lessonTimes = Kernel.DB.LessonTimeRepository.GetAll();
            var models = new List<LessonTimeModel>();

            LessonTimeMapper mapper = new LessonTimeMapper();

            for (int i = 0; i < lessonTimes.Count; i++)
            {
                var entity = lessonTimes[i];
                var model = mapper.Map(entity);
                model.No = i + 1;

                models.Add(model);
            }
            return models;
        }
        public List<ClassRoomModel> GetClassRooms()
        {
            var rooms = Kernel.DB.ClassRoomRepository.GetAll();
            var models = new List<ClassRoomModel>();

            ClassRoomMapper mapper = new ClassRoomMapper();

            for (int i = 0; i < rooms.Count; i++)
            {
                var entity = rooms[i];
                var model = mapper.Map(entity);
                model.No = i + 1;

                models.Add(model);
            }
            return models;
        }
        public List<TeacherSubjectModel> GetTeacherSubjects()
        {
            var tSubjects = Kernel.DB.TeacherSubjectRepository.GetAll();
            var tSubjectModels = new List<TeacherSubjectModel>();

            TeacherSubjectMapper mapper = new TeacherSubjectMapper();

            for (int i = 0; i < tSubjects.Count; i++)
            {
                var entity = tSubjects[i];
                var model = mapper.Map(entity);
                model.No = i + 1;
                tSubjectModels.Add(model);  
            }
            return tSubjectModels;
        }
        public List<UserModel> GetUsers()
        {
            var users = Kernel.DB.UserRepository.GetAll();
            var models =new List<UserModel>();

            UserMapper mapper = new UserMapper();

            for (int i = 0; i < users.Count; i++)
            {
                var entity = users[i];
                var model = mapper.Map(entity);
                model.No = i + 1;

                models.Add(model);
            }
            return models;

        }
        public List<ExamScoreModel> GetExamScores()
        {
            var examScores = Kernel.DB.ExamScoreRepository.GetAll();
            var models = new List<ExamScoreModel>();

            ExamScoreMapper mapper = new ExamScoreMapper();

            for (int i = 0; i < examScores.Count; i++)
            {
                var entity = examScores[i];

                var model = mapper.Map(entity); 
                model.No= i + 1;

                models.Add(model);
            }

            return models;

        }
    }
}
