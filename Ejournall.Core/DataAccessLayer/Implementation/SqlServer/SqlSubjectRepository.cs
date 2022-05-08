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
    public class SqlSubjectRepository:ISubjectRepository
    {
        private readonly string connectionString;
        public SqlSubjectRepository(string conString)
        {
            this.connectionString = conString;
        }

        public List<Subject> GetAll()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string cmdText = "Select * from Subjects where Status = 1";

                using(SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Subject> sbjs = new List<Subject>();

                    while (reader.Read())
                    {
                        Subject sbj = new Subject();

                        sbj.Id = (int)reader["Id"];
                        sbj.Name = (string)reader["Name"];
                        sbj.Hours = (int)reader["Hours"];
                        sbj.Limit = (int)reader["Limit"];

                        sbjs.Add(sbj);
                    }
                    return sbjs;
                }
            }
        }
        public bool Insert(Subject sbj)
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string cmdText = "Insert Into Subjects values(@Name,@Hours,@Limit,1)";
                using(SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    cmd.Parameters.AddWithValue("@Name",sbj.Name);
                    cmd.Parameters.AddWithValue("@Hours", sbj.Hours);
                    cmd.Parameters.AddWithValue("@Limit", sbj.Limit);

                    int affectedRowsCount = cmd.ExecuteNonQuery();
                    return affectedRowsCount == 1;
                }
            }
        }
        public bool Update(Subject sbj)
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string cmdText = $"Update Subjects Set Name = @name, Hours = @hours, Limit = @limit" +
                    $" where Id = @id";
                using(SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    cmd.Parameters.AddWithValue("@name", sbj.Name);
                    cmd.Parameters.AddWithValue("@hours", sbj.Hours);
                    cmd.Parameters.AddWithValue("@limit", sbj.Limit);
                    cmd.Parameters.AddWithValue("@id", sbj.Id);

                    int affectedRowsCount = cmd.ExecuteNonQuery();
                    return affectedRowsCount == 1;
                }
            }
        }
        public bool Delete(int Id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string cmdText = $"Update Subjects Set Status = 0 Where id = {Id}";
                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    int affectedRows = cmd.ExecuteNonQuery();
                    return affectedRows == 1;
                }
            }
        }

    }
}
