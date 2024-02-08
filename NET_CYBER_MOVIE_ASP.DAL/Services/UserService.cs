using Microsoft.Data.SqlClient;
using NET_CYBER_MOVIE_ASP.DAL.Interfaces;
using NET_CYBER_MOVIE_ASP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_CYBER_MOVIE_ASP.DAL.Services
{
    public class UserService : IUserService
    {

        private readonly SqlConnection _connection;

        public UserService(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Create(User user)
        {
            using(SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "NewUser";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@UserName", user.UserName);

                _connection.Open();

                command.ExecuteNonQuery();

                _connection.Close();

            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            List<User> users= new List<User>();

            using(SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = 
                    "SELECT Id, LastName, FirstName, Username, Email FROM [dbo].[User]";

                _connection.Open();

                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User()
                        {
                            Id = reader.GetInt32(0),
                            LastName = reader.GetString(1),
                            FirstName = reader.GetString(2),
                            UserName = reader.GetString(3),
                            Email = reader.GetString(4),

                        }) ; 
                    }
                }

                _connection.Close() ;
                return users ;
            }
        }

        public User? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
