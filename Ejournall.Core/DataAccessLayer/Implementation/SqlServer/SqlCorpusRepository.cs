using Ejournall.DataAccessLayer.Abstraction;
using Ejournall.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Ejournall.Core.DataAccessLayer.Abstraction;
using Ejournall.Core.Entities;

namespace Ejournall.Core.DataAccessLayer.Implementation.SqlServer
{
    public class SqlCorpusRepository : ICorpusRepository
    {
        private readonly string connectionString;
        public SqlCorpusRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public bool Delete(int Id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string cmdText = $"Update Corpuses Set status = 0 where id = {Id}";
                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {

                    int affectedRows = cmd.ExecuteNonQuery();
                    return affectedRows == 1;
                }
            }
        }

        public List<Corpus> GetAll()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string cmdText = "Select *from Corpuses";

                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    List<Corpus> list = new List<Corpus>();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Corpus corpus = new Corpus();

                        corpus.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        corpus.Name = reader.GetString(reader.GetOrdinal("Name"));
                        corpus.CorpusNo = reader.GetInt32(reader.GetOrdinal("CorpusNo"));

                        list.Add(corpus);
                    }

                    return list;
                }
            }
        }

        public bool Insert(Corpus entity)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string cmdText = "Insert Into Corpuses values(@Name, @CorpusNo, 1)";

                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    cmd.Parameters.AddWithValue("@Name", entity.Name);
                    cmd.Parameters.AddWithValue("@CorpusNo", entity.CorpusNo);

                    int affectedRows = cmd.ExecuteNonQuery();
                    return affectedRows == 1;
                }
            }
        }

        public bool Update(Corpus entity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "Update Corpuses " +
                    "Set Name = @name," +
                    "CorpusNo = @CorpusNo " +
                    "where id = @id";

                int rowCount = 0;

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@name", entity.Name);
                    cmd.Parameters.AddWithValue("@CorpusNo", entity.CorpusNo);
                    cmd.Parameters.AddWithValue("@id", entity.Id);

                    rowCount = cmd.ExecuteNonQuery();
                }
                return rowCount == 1;
            }
        }
    }
}
