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
        private readonly IDbConnection _connection;

        public MovieService(IDbConnection connection)
        {
            _connection = connection;
        }

        public void AddMovie(Movie movie)
        {
            using(IDbCommand command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Movie (PosterUrl, Title, Description, Release, Score)" +
                                      "VALUES (@PosterUrl, @Title, @Description, @Release, @Score)  ";


                command.Parameters.Add(new SqlParameter("@PosterUrl", movie.PosterUrl));
                command.Parameters.Add(new SqlParameter("@Title", movie.Title));
                command.Parameters.Add(new SqlParameter("@Description", movie.Description));
                command.Parameters.Add(new SqlParameter("@Release", movie.Release));
                command.Parameters.Add(new SqlParameter("@Score", movie.Score));
                _connection.Open();

                command.ExecuteNonQuery();
                _connection.Close();
            }
   
        }

        public void DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetAll()
        {
            throw new NotImplementedException();
        }

        public Movie? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
