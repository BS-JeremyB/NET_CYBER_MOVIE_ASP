using Microsoft.Data.SqlClient;
using NET_CYBER_MOVIE_ASP.DAL.Interfaces;
using NET_CYBER_MOVIE_ASP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_CYBER_MOVIE_ASP.DAL.Services
{
    internal class UserMoviesService : IUserMoviesService
    {
        private readonly SqlConnection _connection;
        private readonly IMovieService _movie;

        public UserMoviesService(SqlConnection connection, IMovieService movie)
        {
            _connection = connection;
            _movie = movie;
        }

        public void AddFavourite(int userId, Movie movie)
        {
            
            _movie.AddMovie(movie);

            using(SqlCommand command = _connection.CreateCommand()) 
            {
                
            }
        }

        public void AddFavourite(int userId, int movieId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetAllByUser(int userId)
        {
            throw new NotImplementedException();
        }

        public void RemoveFavourite(int userId, int movieId)
        {
            throw new NotImplementedException();
        }
    }
}
