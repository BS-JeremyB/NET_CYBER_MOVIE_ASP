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

    public class MovieService : IMovieService
    {
        private readonly SqlConnection _connection;

        public MovieService(SqlConnection connection)
        {
            _connection = connection;
        }

        public void AddMovie(Movie movie)
        {
            using(SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Movie (PosterUrl, Title, Description, Release, Score)" +
                                      "VALUES (@PosterUrl, @Title, @Description, @Release, @Score)  ";


                command.Parameters.AddWithValue("@PosterUrl", movie.PosterUrl); 
                command.Parameters.AddWithValue("@Title", movie.Title); 
                command.Parameters.AddWithValue("@Description", movie.Description); 
                command.Parameters.AddWithValue("@Release", movie.Release); 
                command.Parameters.AddWithValue("@Score", movie.Score); 
    
                _connection.Open();

                command.ExecuteNonQuery();
                _connection.Close();
            }
   
        }

        public void DeleteMovie(int id)
        {
            using(SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Movie WHERE @id = Id";
                command.Parameters.AddWithValue("@id", id);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();

            }
        }

        public IEnumerable<Movie> GetAll()
        {

            List<Movie> movies = new List<Movie>();

            using(SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Movie";

                _connection.Open();
                using(SqlDataReader reader = command.ExecuteReader())
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

        public Movie? GetById(int id)
        {
            Movie movie = null;
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Movie WHERE @id = Id";

                command.Parameters.AddWithValue("@id", id);

                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        movie = new Movie
                        {
                            Id = reader.GetInt32("id"),
                            PosterUrl = reader.GetString("posterurl"),
                            Title = reader.GetString("title"),
                            Description = reader.GetString("description"),
                            Release = reader.GetDateTime("release"),
                            Score = reader.GetInt32("Score")
                        };
                    }
                }

                _connection.Close();
                return movie is not null ? movie : null ;
            }
        }

        public void UpdateMovie(int id, Movie movie)
        {
            using(SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "UPDATE Movie SET PosterUrl = @PosterUrl, Title = @Title, Description = @Description, Release = @Release, Score = @Score WHERE @id = Id";

                command.Parameters.AddWithValue("@PosterUrl", movie.PosterUrl);
                command.Parameters.AddWithValue("@Title", movie.Title);
                command.Parameters.AddWithValue("@Description", movie.Description);
                command.Parameters.AddWithValue("@Release", movie.Release);
                command.Parameters.AddWithValue("@Score", movie.Score);
                command.Parameters.AddWithValue("@id",id);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();


            }
        }
    }
}
