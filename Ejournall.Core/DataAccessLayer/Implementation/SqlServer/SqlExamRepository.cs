using Ejournall.DataAccessLayer.Abstraction;
using Ejournall.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Ejournall.Core.DataAccessLayer.Abstraction;
using Ejournall.Core.Entities;
using System.Globalization;

namespace Ejournall.Core.DataAccessLayer.Implementation.SqlServer
{
    public class SqlExamRepository : IExamRepository
    {
        private readonly string connectionString;
        public SqlExamRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public bool Delete(int Id)
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string cmdText = $"Update Exams Set status = 0 Where Id = {Id}";

                using(SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    int affectedRowCount = cmd.ExecuteNonQuery();
                    return affectedRowCount == 1;
                }
            }
        }

        public List<Exam> GetAll()
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string cmdText = "Select E.Id as EID, E.ExamDate, E.StartTime, E.EndTime, L.Id as [LID],TS.ID as [TSID], " +
                    "G.ID as GID, G.Name as [Group], G.Status as [GroupStatus], " +
                    "SPC.ID as [SpecID],SPC.Name as [Speciality], SPC.Status as [SpecialityStatus], " +
                    "FCLT.ID as [FCLTID],FCLT.Name as [Faculty], FCLT.Status as [FacultyStatus]," +
                    "T.ID as [TID],T.Name as [Teacher],T.Surname as [TSurname],T.Birthdate as [TBirth], " +
                    "T.WorkExperience as [TExperience],T.Status as [Teacherstatus]," +
                    "SBJ.ID as [SBJID],SBJ.Name as [Subject],SBJ.hours as [Hours],SBJ.Limit as [Limit], " +
                    "SBJ.Status as [SubjectStatus]," +
                    "CLSRM.ID as [ClassID],CLSRM.ClassNo as [Class],CLSRM.CorpusID as [CorpusID], " +
                    "SMSTR.ID as [SMSTRID],SMSTR.Name as [Semester],SMSTR.StartDate as [StartDate], " +
                    "SMSTR.EndDate as [EndDate] " +
                    "from Exams as E " +
                    "inner join Lessons as L on E.LessonId = L.Id " +
                    "inner join Groups as G on G.Id = L.GroupID " +
                    "inner join Speciality as SPC on SPC.ID = G.SpecialityID " +
                    "inner join Faculty as FCLT on SPC.FacultyId = FCLT.ID " +
                    "inner join TeacherSubject as TS on L.TeacherSubjectID = TS.ID " +
                    "inner join Teachers as T on T.Id = TS.TeacherID " +
                    "inner join Subjects as SBJ on SBJ.Id = TS.SubjectID " +
                    "inner join Classrooms as CLSRM on CLSRM.ID = L.ClassID " +
                    "inner join Semesters as SMSTR on L.SemesterID = SMSTR.ID " +
                    "where G.Status = 1 and SPC.Status = 1 and T.Status = 1 and SBJ.Status = 1 and L.Status = 1 and E.Status = 1 ";

                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    var reader = cmd.ExecuteReader();

                    List<Exam> exams = new List<Exam>();

                    while (reader.Read())
                    {
                        Exam exam = new Exam()
                        {
                            Id = (int)reader["EID"],
                            StartTime = (DateTime)reader["StartTime"],
                            EndTime = (DateTime)reader["EndTime"],
                            ExamDate = (DateTime)reader["ExamDate"],

                            Lesson = new Lesson()
                            {
                                Id = (int)reader["LID"],
                                Group = new Group()
                                {
                                    Id = (int)reader["GID"],
                                    Name = (string)reader["Group"],

                                    Speciality = new Speciality()
                                    {
                                        Id = (int)reader["SpecID"],
                                        Name = (string)reader["Speciality"],

                                        Faculty = new Faculty()
                                        {
                                            Id = (int)reader["FCLTID"],
                                            Name = (string)reader["Faculty"],
                                        }
                                    }
                                },
                                Semester = new Semester()
                                {
                                    Id = (int)reader["SMSTRID"],
                                    Name = (string)reader["Semester"]
                                },
                                Subject = new TeacherSubject()
                                {
                                    Id = (int)reader["TSID"],

                                    Subject = new Subject()
                                    {
                                        Id = (int)reader["SBJID"],
                                        Name = (string)reader["Subject"],
                                        Hours = (int)reader["Hours"],
                                        Limit = (int)reader["Limit"]
                                    },
                                    Teacher = new Teacher()
                                    {
                                        Id = (int)reader["TID"],
                                        Name = (string)reader["Teacher"],
                                        Surname = (string)reader["Tsurname"],
                                        BirthDate = reader.GetDateTime(reader.GetOrdinal("TBirth")).ToString("dd/MM/yyyy"),
                                        WorkExperience = (int)reader["TExperience"],
                                    }
                                },
                                Classroom = new ClassRoom()
                                {
                                    Id = (int)reader["ClassID"],
                                    ClassNo = (int)reader["Class"],
                                    CorpusID = (int)reader["CorpusID"]
                                }
                            }
                        };


                        exams.Add(exam);
                    }

                    return exams;
                }
            }
        }

        public bool Insert(Exam entity)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string cmdText = "Insert Into Exams values(@LessonId, @ExamDate, @StartTime, @EndTime, 1)";

                using(SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    cmd.Parameters.AddWithValue("@ExamDate", entity.ExamDate);
                    cmd.Parameters.AddWithValue("@StartTime", entity.StartTime);
                    cmd.Parameters.AddWithValue("@EndTime", entity.EndTime);
                    cmd.Parameters.AddWithValue("@LessonId", entity.Lesson.Id);

                    int affectedRows = cmd.ExecuteNonQuery();
                    return affectedRows == 1;
                }
            }
        }

        public bool Update(Exam entity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "Update Exams " +
                    "Set ExamDate = @ExamDate," +
                    "LessonId = @LessonId, StartTime = @StartTime, EndTime = @EndTime " +
                    "where id = @id";

                int rowCount = 0;
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@ExamDate", entity.ExamDate);
                    cmd.Parameters.AddWithValue("@StartTime", entity.StartTime);
                    cmd.Parameters.AddWithValue("@EndTime", entity.EndTime);
                    cmd.Parameters.AddWithValue("@LessonId", entity.Lesson.Id);
                    cmd.Parameters.AddWithValue("@id", entity.Id);

                    rowCount = cmd.ExecuteNonQuery();
                }

                return rowCount == 1;
            }
        }
    }
}
