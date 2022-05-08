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
    public class SqlSemesterRepository : ISemesterRepository
    {
        private readonly string connectionString;

        public SqlSemesterRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool Delete(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = $"Delete from semesters where Id = {Id}";

                int rowCount = 0;
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    rowCount = cmd.ExecuteNonQuery();
                }
                return rowCount == 1;
            }
        }

        public List<Semester> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                string cmdText = $"Select * from Semesters";

                List<Semester> semesters = new List<Semester>();
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Semester semester = new Semester();

                        semester.Id = (int)reader["Id"];
                        semester.Name = (string)reader["Name"];
                        semester.StartDate = (DateTime)reader["StartDate"];
                        semester.EndDate = (DateTime)reader["EndDate"];

                        semesters.Add(semester);
                    }
                    return semesters;
                }
            }
        }

        public bool Insert(Semester semester)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = $"Insert Into Semester values(@name,@startDate,@endDate)";

                int rowCount = 0;
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@name", semester.Name);
                    cmd.Parameters.AddWithValue("@startDate", semester.StartDate);
                    cmd.Parameters.AddWithValue("@endDate", semester.EndDate);

                    rowCount = cmd.ExecuteNonQuery();
                }
                return rowCount == 1;
            }
        }

        public bool Update(Semester semester)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = $"Update Semesters Set Name = @name,StartDate = @startDate, EndDate = @endDate" +
                    $"Where Id = @id";

                int rowCount = 0;
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@name", semester.Name);
                    cmd.Parameters.AddWithValue("@startDate", semester.StartDate);
                    cmd.Parameters.AddWithValue("@endDate", semester.EndDate);
                    cmd.Parameters.AddWithValue("@id", semester.Id);

                    rowCount = cmd.ExecuteNonQuery();
                }
                return (rowCount == 1);
            }
        }
    }
}
