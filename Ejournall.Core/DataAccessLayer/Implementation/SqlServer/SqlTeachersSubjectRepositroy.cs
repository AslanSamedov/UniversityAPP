using Ejournall.DataAccessLayer.Abstraction;
using Ejournall.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.DataAccessLayer.SqlServer
{
    public class SqlTeachersSubjectRepositroy : ITeacherSubjectRepository
    {
        private readonly string connectionString;

        public SqlTeachersSubjectRepositroy(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool Delete(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = $"Update Teachers Set Status = 0 where id =@id";

                int rowCount = 0;
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@id", Id);
                    rowCount = cmd.ExecuteNonQuery();
                }
                return rowCount == 1;
            }
        }

        public List<TeacherSubject> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "select TS.Id as [TSID]," +
                    "T.Id as [TID],T.Name as [Teacher], T.Surname as [TSurname],T.Birthdate as [TBirth],T.WorkExperience as [Experience]," +
                    "S.Id as [SID],S.name as [Subject], S.Hours as [Hours],S.Limit as [Limit] " +
                    "from TeacherSubject as TS " +
                    "inner join Teachers as T on T.Id = TS.TeacherId " +
                    "inner join Subjects as S on S.Id = TS.SubjectId " +
                    "where T.Status = 1 and S.Status = 1 and TS.Status = 1 ";

                List<TeacherSubject> tSubjects = new List<TeacherSubject>();
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        TeacherSubject tSubject = new TeacherSubject()
                        {
                            Id = (int)reader["TSID"],

                            Teacher = new Teacher()
                            {
                                Id = (int)reader["TID"],
                                Name = (string)reader["Teacher"],
                                Surname = (string)reader["TSurname"],
                                BirthDate = reader.GetDateTime(reader.GetOrdinal("TBirth")).ToString("dd/MM/yyyy"),
                                WorkExperience = (int)reader["Experience"],
                            },
                            Subject = new Subject()
                            {
                                Id = (int)reader["SID"],
                                Name = (string)reader["Subject"],
                                Hours = (int)reader["Hours"],
                                Limit = (int)reader["Limit"]
                            }
                        };

                        tSubjects.Add(tSubject);
                    }
                    return tSubjects;
                }
            }
        }

        public bool Insert(TeacherSubject Tsubject)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = $"Insert into TeacherSubject values (@subjectID,@teacherID,1)";

                int rowCount = 0;
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@subjectID", Tsubject.Subject.Id);
                    cmd.Parameters.AddWithValue("@teacherID", Tsubject.Teacher.Id);

                    rowCount = cmd.ExecuteNonQuery();
                }
                return rowCount == 1;
            }
        }

        public bool Update(TeacherSubject tSubject)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = $"Update TeacherSubject " +
                    $"Set SubjectID = @subjectID" +
                    $",TeacherID = @teacherID " +
                    $"Where Id = @id";

                int rowCount = 0;
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@subjectID", tSubject.Subject.Id);
                    cmd.Parameters.AddWithValue("@teacherID", tSubject.Teacher.Id);
                    cmd.Parameters.AddWithValue("@id", tSubject.Id);

                    rowCount = cmd.ExecuteNonQuery();
                }
                return rowCount == 1;
            }
        }
    }
}
