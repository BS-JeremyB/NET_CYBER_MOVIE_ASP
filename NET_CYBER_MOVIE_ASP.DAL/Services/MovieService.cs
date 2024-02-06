using DemoASPMVC_DAL.Services;
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

    public class MovieService : BaseRepository<Movie>, IMovieService
    {

        public MovieService(IDbConnection connection) : base(connection)
        {
        }

        public void AddFavorite(int idUser, int idMovie)
        {
            throw new NotImplementedException();
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
            // create the dele command
            using (IDbCommand command = _connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Movie WHERE Id = @id";
                command.Parameters.Add(new SqlParameter("@id", id));
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }


        public IEnumerable<Movie> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public void UpdateMovie(Movie movie)
        {
            //create the update command
            using (IDbCommand command = _connection.CreateCommand())
            {
                command.CommandText = "UPDATE Movie SET PosterUrl = @PosterUrl, Title = @Title, Description = @Description, Release = @Release, Score = @Score WHERE Id = @Id";
                command.Parameters.Add(new SqlParameter("@PosterUrl", movie.PosterUrl));
                command.Parameters.Add(new SqlParameter("@Title", movie.Title));
                command.Parameters.Add(new SqlParameter("@Description", movie.Description));
                command.Parameters.Add(new SqlParameter("@Release", movie.Release));
                command.Parameters.Add(new SqlParameter("@Score", movie.Score));
                command.Parameters.Add(new SqlParameter("@Id", movie.Id));
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }   
        }

        protected override Movie Mapper(IDataReader reader)
        {

            return new Movie
            { 
                Id = (int)reader["Id"],
                PosterUrl = reader["PosterUrl"].ToString(),
                Title = reader["Title"].ToString(),
                Description = reader["Description"].ToString(),
                Release = (DateTime)reader["Release"],
                Score = (int)reader["Score"]
            };
        }
    }
}
