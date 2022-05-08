using Ejournall.DataAccessLayer.Abstraction;
using Ejournall.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ejournall.DataAccessLayer.SqlServer.Repositories
{
    public class SqlSpecialityRepository : ISpecialityRepository
    {
        private readonly string connectionString;
        public SqlSpecialityRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = $"Update Speciality set Status = 0 where Id = {id}";

                int rowcount = 0;
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    rowcount = cmd.ExecuteNonQuery();
                }
                return rowcount == 1;
            }

        }

        public List<Speciality> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                string cmdText = "select S.ID as SID , S.Name as [Speciality]," +
                                   "F.Id as FID,F.Name as [Faculty] from Speciality as S " +
                                "inner join Faculty as F on F.Id = S.FacultyId where S.Status = 1 and F.Status = 1";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Speciality> specialities = new List<Speciality>();

                    while (reader.Read())
                    {
                        Speciality speciality = new Speciality();
                        speciality.Id = (int)reader["SID"];
                        speciality.Name = (string)reader["Speciality"];
                        speciality.FacultyId = (int)reader["FID"];

                        speciality.Faculty = new Faculty()
                        {
                            Id = (int)reader["FID"],
                            Name = (string)reader["Faculty"],
                        };

                        specialities.Add(speciality);

                    }
                    return specialities;
                }
            }
        }

        public bool Insert(Speciality speciality)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = $"Insert into Speciality values(@name,@facultyId,1)";
                int rowCount = 0;

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@name", speciality.Name);
                    cmd.Parameters.AddWithValue("facultyId", speciality.Faculty.Id);

                    rowCount = cmd.ExecuteNonQuery();

                }
                return rowCount == 1;
            }
        }

        public bool Update(Speciality speciality)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "Update Speciality " +
                    "Set Name = @name, facultyid = @fId, Status = 1 " + " where Id = @id";


                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@name", speciality.Name);
                    cmd.Parameters.AddWithValue("@Id", speciality.Id);
                    cmd.Parameters.AddWithValue("@fId", speciality.Faculty.Id);
                    int rowCount = cmd.ExecuteNonQuery();

                    return rowCount == 1;
                }
            }
        }
    }
}
