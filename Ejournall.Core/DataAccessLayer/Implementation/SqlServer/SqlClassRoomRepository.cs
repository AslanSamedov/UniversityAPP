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
    public class SqlClassRoomRepository : IClassRoomRepository
    {
        private readonly string connectionString;
        public SqlClassRoomRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public bool Delete(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = $"Update ClassRooms set Status = 0 where Id = {Id}";

                int rowcount = 0;
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    rowcount = cmd.ExecuteNonQuery();
                }
                return rowcount == 1;
            }
        }

        public List<ClassRoom> GetAll()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string cmdText = "Select * from ClassRooms";

                using(SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ClassRoom> list = new List<ClassRoom>();
                    while (reader.Read())
                    {
                        ClassRoom room = new ClassRoom();
                        room.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        room.ClassNo = reader.GetInt32(reader.GetOrdinal("ClassNo"));
                        room.CorpusID = reader.GetInt32(reader.GetOrdinal("CorpusID"));

                        list.Add(room);
                    }
                    return list;
                }
            }
        }

        public bool Insert(ClassRoom entity)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string cmdText = "Insert Into ClassRooms values (@ClassNo,@CorpusId)";
                using(SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    cmd.Parameters.AddWithValue("@ClassNo", entity.ClassNo);
                    cmd.Parameters.AddWithValue("@CorpusId",entity.CorpusID);

                    int affectedRows = cmd.ExecuteNonQuery();
                    return affectedRows == 1;
                }
            }
        }

        public bool Update(ClassRoom entity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "Update ClassRooms " +
                    "Set ClassNo = @ClassNo, CorpusId = @CorpusId where Id = @id";


                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@ClassNo", entity.ClassNo);
                    cmd.Parameters.AddWithValue("@CorpusId", entity.CorpusID);
                    cmd.Parameters.AddWithValue("@id", entity.Id);
                    int rowCount = cmd.ExecuteNonQuery();

                    return rowCount == 1;
                }
            }
        }
    }
}
