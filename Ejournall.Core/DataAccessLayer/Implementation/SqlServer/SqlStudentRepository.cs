using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejournall.Entities;
using Ejournall.Abstraction;
using Ejournall.Core.Entities;
using Ejournall.DataAccessLayer.Abstraction;

namespace Ejournall.DataAccessLayer.SqlServer
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly string connectionString;

        public SqlStudentRepository(string conString)
        {
            this.connectionString = conString;
        }

        public List<Student> GetAll()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string cmdText = "Select " +
                    "S.ID as StID, S.Name as StName, S.Surname as StSurname,S.BirthDate as StBirthdate," +
                    "G.ID as GID, G.Name as [Group],G.SpecialityID," +
                    "SP.Id as SPID ,SP.Name as Speciality,SP.FacultyID ," +
                    "F.Id as FID, F.Name as FNAME from Students as S inner join Groups as G " +
                    "on S.GroupID = G.ID inner join Speciality as SP on SP.ID = G.SpecialityID " +
                    "inner join Faculty as F on F.ID = SP.FacultyID where S.Status = 1 and G.Status = 1" ;

                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    List<Student> stds = new List<Student>();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Student st = new Student();
                        st.Id = reader.GetInt32(reader.GetOrdinal("StID"));
                        st.Name = reader.GetString(reader.GetOrdinal("StName"));
                        st.Surname = reader.GetString(reader.GetOrdinal("StSurname"));
                        st.Birthdate = reader.GetDateTime(reader.GetOrdinal("StBirthdate")).ToString("dd/MM/yyyy");
                        st.GroupId = reader.GetInt32(reader.GetOrdinal("GID"));
                        st.Group = new Group()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("GID")),
                            Name = reader.GetString(reader.GetOrdinal("Group")),
                            Speciality = new Speciality()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("SPID")),
                                Name = reader.GetString(reader.GetOrdinal("Speciality")),
                                FacultyId = reader.GetInt32(reader.GetOrdinal("FacultyId")),
                                Faculty = new Faculty()
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("FID")),
                                    Name = reader.GetString(reader.GetOrdinal("FNAME"))
                                }
                            }
                        };

                        stds.Add(st);
                    }
                    return stds;
                }
            }
        }
        public bool Insert(Student st)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string cmdText = "Insert Into Students values(@name,@surname,@birthdate,@groupId,1)";
                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    cmd.Parameters.AddWithValue("@name", st.Name);
                    cmd.Parameters.AddWithValue("@surname", st.Surname);
                    cmd.Parameters.AddWithValue("@birthdate", DateTime.Parse(st.Birthdate).ToString("MM/dd/yyyy"));
                    cmd.Parameters.AddWithValue("@groupid", st.Group.Id);

                    int affectedRow = cmd.ExecuteNonQuery();
                    return affectedRow == 1;
                }
            }
        }
        public bool Update(Student st)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string cmdText = $"Update Students Set Name = @name, Surname = @surname, Birthdate = @birthdate," +
                    $"GroupId = @GroupId where Id =@Id";

                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    cmd.Parameters.AddWithValue("@name", st.Name);
                    cmd.Parameters.AddWithValue("@surname", st.Surname);
                    cmd.Parameters.AddWithValue("@birthdate", DateTime.Parse(st.Birthdate).ToString("MM/dd/yyyy"));
                    cmd.Parameters.AddWithValue("@GroupId", st.Group.Id);
                    cmd.Parameters.AddWithValue("@Id", st.Id);

                    int affectedCount = cmd.ExecuteNonQuery();

                    return affectedCount == 1;
                }
            }
        }
        public bool Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string cmdtext = $"Update Students Set Status = 0 where id = @id";
                using (SqlCommand cmd = new SqlCommand(cmdtext, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int affectedRows = cmd.ExecuteNonQuery();
                    return affectedRows == 1;
                }

            }
        }
    }
}
