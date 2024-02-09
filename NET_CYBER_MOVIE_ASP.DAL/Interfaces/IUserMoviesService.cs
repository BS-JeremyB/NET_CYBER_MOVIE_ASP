using NET_CYBER_MOVIE_ASP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_CYBER_MOVIE_ASP.DAL.Interfaces
{
    public interface IUserMoviesService
    {
        IEnumerable<Movie> GetAllByUser(int userId);
        void AddFavourite(int userId, int movieId);
        void RemoveFavourite(int userId, int movieId);
        bool IsMovieInFavourites(int userId, int movieId);
    }
}
