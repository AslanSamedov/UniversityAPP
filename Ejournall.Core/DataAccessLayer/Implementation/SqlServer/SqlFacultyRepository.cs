using Ejournall.DataAccessLayer.Abstraction;
using Ejournall.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ejournall.DataAccessLayer.SqlServer
{
    public class SqlFacultyRepository:IFacultyRepository
    {
        private readonly string connectionString;
        public SqlFacultyRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public bool Delete(int id)
        {
            using(SqlConnection connection=new SqlConnection(connectionString))
            {
                connection.Open();

                string cmdText = $"Delete from Faculty where Id = {id}";  
                int rowCount = 0;

                using(SqlCommand cmd=new SqlCommand(cmdText, connection))
                {
                    rowCount = cmd.ExecuteNonQuery();
                }
                return rowCount == 1;
            }
        }

        public List<Faculty> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = $"Select * from Faculty";
                List<Faculty> faculties = new List<Faculty>();
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        Faculty faculty = new Faculty();
                        faculty.Id = (int)reader["Id"];
                        faculty.Name = (string)reader["Name"];

                        faculties.Add(faculty);

                    }
                    return faculties;
                }
            }
        }

        public bool Insert(Faculty faculty)
        {
            using(SqlConnection connection=new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = $"Insert into Faculty values(@Name)";
                int rowCount = 0;
                using(SqlCommand cmd = new SqlCommand(@cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@name", faculty.Name);

                    rowCount= cmd.ExecuteNonQuery();
                }
                return rowCount == 1;
            }
        }

        public bool Update(Faculty faculty)
        {
            using(SqlConnection connection=new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = $"Update Faculty set Name=@name" +
                    $"Where Id=@id";
                int rowCount = 0;
                using( SqlCommand cmd = new SqlCommand(@cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@name", faculty.Name);
                    cmd.Parameters.AddWithValue("@Id",faculty.Id);

                    rowCount=cmd.ExecuteNonQuery();
                }

                return rowCount == 1;
            }
        }
    }
}
