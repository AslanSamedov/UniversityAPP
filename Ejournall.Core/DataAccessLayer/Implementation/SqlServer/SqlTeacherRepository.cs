using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Ejournall.DataAccessLayer.Abstraction;
using Ejournall.Entities;

namespace Ejournall.DataAccessLayer.SqlServer
{
    public class SqlTeacherRepository : ITeacherRepository
    {
        private readonly string connectionSting;

        public SqlTeacherRepository(string connectionString)
        {
            this.connectionSting = connectionString;
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionSting))
            {
                connection.Open();

                string cmdTxt = $"Update Teachers Set Status = 0 where Id = {id}";
                int rowCount = 0;

                using (SqlCommand cmd = new SqlCommand(cmdTxt, connection))
                {
                    rowCount = cmd.ExecuteNonQuery();
                }

                return rowCount == 1;
            }
        }
        public List<Teacher> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionSting))
            {
                connection.Open();

                string cmdText = $"Select * from Teachers where Status = 1";
                List<Teacher> teachers = new List<Teacher>();

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Teacher teacher = new Teacher();
                        teacher.Id = (int)reader["Id"];
                        teacher.Name = (string)reader["Name"];
                        teacher.Surname = (string)reader["Surname"];
                        teacher.BirthDate = reader.GetDateTime(reader.GetOrdinal("BirthDate")).ToString("dd/MM/yyyy");
                        teacher.WorkExperience = (int)reader["WorkExperience"];
                        teacher.Status = (bool)reader["Status"];

                        teachers.Add(teacher);
                    }

                    return teachers;
                }

            }

        }

        public bool Insert(Teacher teacher)
        {
            using (SqlConnection connection = new SqlConnection(connectionSting))
            {
                connection.Open();

                string cmdTxt = $"Insert into Teachers values (@name,@surname,@birthDate,@workExperience ,1)";

                int rowCount = 0;

                using (SqlCommand cmd = new SqlCommand(@cmdTxt, connection))
                {
                    cmd.Parameters.AddWithValue("@name", teacher.Name);
                    cmd.Parameters.AddWithValue("@surname", teacher.Surname);
                    cmd.Parameters.AddWithValue("@birthDate", DateTime.Parse(teacher.BirthDate).ToString("MM/dd/yyyy"));
                    cmd.Parameters.AddWithValue("@workExperience", teacher.WorkExperience);
                    
                    rowCount = cmd.ExecuteNonQuery();
                }
                return rowCount == 1;
            }
        }

        public bool Update(Teacher teacher)
        {
            using (SqlConnection connection = new SqlConnection(connectionSting))
            {
                connection.Open();

                string cmdText = $"update Teachers set " +
                    $"Name =@name," +
                    $"Surname = @surname," +
                    $"BirthDate = @birthDate," +
                    $"WorkExperience = @workExperience " +
                    $"Where Id = @id";

                int rowCount = 0;

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@name", teacher.Name);
                    cmd.Parameters.AddWithValue("@surname",teacher.Surname);
                    cmd.Parameters.AddWithValue("@birthDate", DateTime.Parse(teacher.BirthDate).ToString("MM/dd/yyyy"));
                    cmd.Parameters.AddWithValue("@WorkExperience",teacher.WorkExperience);
                    cmd.Parameters.AddWithValue("@Id", teacher.Id);

                    rowCount = cmd.ExecuteNonQuery();
                }

                return rowCount == 1;   
            }
        }
    }
}
