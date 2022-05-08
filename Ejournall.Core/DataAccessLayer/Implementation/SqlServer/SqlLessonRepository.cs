using Ejournall.Core.DataAccessLayer.Abstraction;
using Ejournall.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejournall.Entities;

namespace Ejournall.Core.DataAccessLayer.Implementation.SqlServer
{
    public class SqlLessonRepository : ILessonRepository
    {
        private readonly string connectionString;
        public SqlLessonRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public bool Delete(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "Update Lessons Set Status = 0 where id = @id";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", Id);

                    return cmd.ExecuteNonQuery() == 1;
                }
            }

        }

        public List<Lesson> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "Select L.Id as [LID],TS.ID as [TSID]," +
                    "G.ID as GID, G.Name as [Group],G.Status as [GroupStatus]," +
                    "SPC.ID as [SpecID],SPC.Name as [Speciality], SPC.Status as [SpecialityStatus]," +
                    "FCLT.ID as [FCLTID],FCLT.Name as [Faculty], FCLT.Status as [FacultyStatus]," +
                    "T.ID as [TID],T.Name as [Teacher],T.Surname as [TSurname],T.Birthdate as [TBirth],T.WorkExperience as [TExperience],T.Status as [Teacherstatus]," +
                    "SBJ.ID as [SBJID],SBJ.Name as [Subject],SBJ.hours as [Hours],SBJ.Limit as [Limit],SBJ.Status as [SubjectStatus]," +
                    "CLSRM.ID as [ClassID],CLSRM.ClassNo as [Class],CLSRM.CorpusID as [CorpusID]," +
                    "SMSTR.ID as [SMSTRID],SMSTR.Name as [Semester],SMSTR.StartDate as [StartDate],SMSTR.EndDate as [EndDate] " +
                    "from Lessons as L " +
                    "inner join Groups as G on G.Id = L.GroupID " +
                    "inner join Speciality as SPC on SPC.ID = G.SpecialityID " +
                    "inner join Faculty as FCLT on SPC.FacultyId = FCLT.ID " +
                    "inner join TeacherSubject as TS on L.TeacherSubjectID = TS.ID " +
                    "inner join Teachers as T on T.Id = TS.TeacherID " +
                    "inner join Subjects as SBJ on SBJ.Id = TS.SubjectID " +
                    "inner join Classrooms as CLSRM on CLSRM.ID = L.ClassID " +
                    "inner join Semesters as SMSTR on L.SemesterID = SMSTR.ID " +
                    "where G.Status = 1 and SPC.Status = 1 and T.Status = 1 and SBJ.Status = 1 and L.Status = 1";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    var reader = cmd.ExecuteReader();

                    List<Lesson> lessons = new List<Lesson>();

                    while (reader.Read())
                    {
                        Lesson lesson = new Lesson()
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
                        };

                        lessons.Add(lesson);
                    }
                    return lessons;
                }
            }
        }

        public bool Insert(Lesson entity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "Insert Into Lessons values (@groupID,@tsID,@classID,@semesterID,1)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {

                    cmd.Parameters.AddWithValue("@groupID", entity.Group.Id);
                    cmd.Parameters.AddWithValue("@tsID", entity.Subject.Id);
                    cmd.Parameters.AddWithValue("@classID", entity.Classroom.Id);
                    cmd.Parameters.AddWithValue("@semesterID", entity.Semester.Id);

                    return cmd.ExecuteNonQuery() == 1;
                }
            }


        }

        public bool Update(Lesson entity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"Update Lessons Set GroupID = @groupID,TeacherSubjectID = @tsID ,ClassID = @clsID ,SemesterId = @smstrID where id = @id";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@groupID", entity.Group.Id);
                    cmd.Parameters.AddWithValue("@tsID", entity.Subject.Id);
                    cmd.Parameters.AddWithValue("@clsID", entity.Classroom.Id);
                    cmd.Parameters.AddWithValue("@smstrID", entity.Semester.Id);
                    cmd.Parameters.AddWithValue("@id", entity.Id);

                    return cmd.ExecuteNonQuery() == 1;
                }

            }


        }
    }
}
