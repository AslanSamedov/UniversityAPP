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
    public class SqlGroupRepostiory : IGroupRepository
    {
        private readonly string connectionString;

        public SqlGroupRepostiory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = $"Update Groups Set Status = 0 where Id =@Id";

                int rowCount = 0;
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    rowCount = cmd.ExecuteNonQuery();
                }
                return rowCount == 1;
            }
        }
        public List<Group> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                string cmdText = $"Select G.Id as GID, G.Name as [Group]," +
                                 $"S.Id as SID,S.Name as [Speciality],S.FacultyId as FID,F.Name as [Faculty] from Groups as G " +
                                 $"inner join Speciality as S on G.SpecialityId = S.Id " +
                                 $"inner join Faculty as F on F.id = S.FacultyId where G.Status = 1";


                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Group> groups = new List<Group>();
                    while (reader.Read())
                    {
                        Group group = new Group();

                        group.Id = (int)reader["GID"];
                        group.Name = (string)reader["Group"];

                        group.Speciality = new Speciality()
                        {
                            Id = (int)reader["SID"],
                            Name = (string)reader["Speciality"],
                            FacultyId = (int)reader["FID"],
                            Faculty = new Faculty()
                            {
                                Id = (int)reader["FID"],
                                Name = (string)reader["Faculty"]
                            }
                        };

                        groups.Add(group);
                    }
                    return groups;
                }
            }

        }
        public bool Insert(Group group)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = $"Insert into Groups values(@name,@specialityID,1)";

                int rowCount = 0;
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@name", group.Name);
                    cmd.Parameters.AddWithValue("@specialityID", group.Speciality.Id);

                    rowCount = cmd.ExecuteNonQuery();
                }
                return rowCount == 1;
            }
        }

        public bool Update(Group group)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "Update Groups " +
                    "Set Name = @name," +
                    "SpecialityID = @specialityID " +
                    "where id = @id";

                int rowCount = 0;
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@name", group.Name);
                    cmd.Parameters.AddWithValue("@specialityID", group.Speciality.Id);
                    cmd.Parameters.AddWithValue("@id", group.Id);

                    rowCount = cmd.ExecuteNonQuery();
                }

                return rowCount == 1;
            }
        }
    }
}
