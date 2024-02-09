using Microsoft.Data.SqlClient;
using NET_CYBER_MOVIE_ASP.DAL.Interfaces;
using NET_CYBER_MOVIE_ASP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_CYBER_MOVIE_ASP.DAL.Services
{
    public class UserMoviesService : IUserMoviesService
    {
        private readonly SqlConnection _connection;

        public UserMoviesService(SqlConnection connection)
        {
            _connection = connection;

        }


        public void AddFavourite(int userId, int movieId)
        {
           using(SqlCommand command = _connection.CreateCommand())
            {
          

                command.CommandText = "INSERT INTO UserMovie (UserId, MovieId)" +
                                      "VALUES (@UserId, @MovieId)";
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@MovieId", movieId);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public IEnumerable<Movie> GetAllByUser(int userId)
        {
            List<Movie> movies = new List<Movie>();

            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM UserMovie U JOIN Movie M  ON M.Id = U.MovieId " +
                                      "WHERE U.UserID = @UserId";

                command.Parameters.AddWithValue("@UserId", userId);

                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        movies.Add(new Movie
                        {
                            Id = reader.GetInt32("id"),
                            PosterUrl = reader.GetString("posterurl"),
                            Title = reader.GetString("title"),
                            Description = reader.GetString("description"),
                            Release = reader.GetDateTime("release"),
                            Score = reader.GetInt32("Score")
                        });
                    }
                }

                _connection.Close();
                return movies;
            }
        }

        public bool IsMovieInFavourites(int userId, int movieId)
        {
            bool isInFavourites = false;

            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM UserMovie WHERE UserId = @UserId AND MovieId = @MovieId";
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@MovieId", movieId);

                _connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());
                _connection.Close();

                isInFavourites = count > 0;
            }

            return isInFavourites;
        }
        public void RemoveFavourite(int userId, int movieId)
        {
            throw new NotImplementedException();
        }
    }
}
