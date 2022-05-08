using Ejournall.Core.Entities;
using Ejournall.DataAccessLayer.Abstraction;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.DataAccessLayer.SqlServer.Repositories
{
    public class SqlUserRepository :IUserRepository
    {
        private readonly string connectionString;

        public SqlUserRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool Delete(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"Delete from Users where Id = {Id}";

                int affectedRows = 0;
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    affectedRows = cmd.ExecuteNonQuery();
                }
                return affectedRows == 1;
            }
        }

        public List<User> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"Select * from Users";

                List<User> users = new List<User>();  
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        User user = new User();

                        user.Id = (int)reader["id"];
                        user.UserName=(string)reader["username"];
                        user.PasswordHash=(string)reader["passwordhash"];
                        user.Mail = (string)reader["Mail"];

                        users.Add(user);    
                    }
                    return users;
                }
            }
        }

        public bool Insert(User entity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"Insert into Users values(@username,@mail,@passwordHash)";

                int affectedRows = 0;
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", entity.UserName);
                    cmd.Parameters.AddWithValue("@mail", entity.Mail);
                    cmd.Parameters.AddWithValue("@passwordHash", entity.PasswordHash);

                    affectedRows = cmd.ExecuteNonQuery();
                }
                return affectedRows == 1;
            }
        }

        public User GetUserByUsername(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"Select * from Users Where [Username] ='{username}'";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        User user = new User();

                        user.Id = (int)reader["id"];
                        user.UserName = (string)reader["username"];
                        user.PasswordHash = (string)reader["PasswordHash"];
                        user.Mail = (string)reader["Mail"];

                        return user;
                    }

                    return null;
                }
            }
        }


        public bool Update(User entity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"Update Users Set [Username] = @username, paswordhash = @pass, mail = @mail where id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", entity.UserName);
                    cmd.Parameters.AddWithValue("@pass", entity.PasswordHash);
                    cmd.Parameters.AddWithValue("@mail", entity.Mail);
                    cmd.Parameters.AddWithValue("@Id", entity.Id);

                    int affectedRows = cmd.ExecuteNonQuery();
                    return affectedRows == 1;
                }
            }
        }
        public bool UpdatePassword(User entity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"Update Users Set paswordhash = @pass where id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@pass", entity.PasswordHash);
                    cmd.Parameters.AddWithValue("@Id", entity.Id);

                    int affectedRows = cmd.ExecuteNonQuery();
                    return affectedRows == 1;
                }
            }
        }

    }
}
