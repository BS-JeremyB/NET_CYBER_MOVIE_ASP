using NET_CYBER_MOVIE_ASP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_CYBER_MOVIE_ASP.DAL.Interfaces
{
    public interface IMovieService
    {

        IEnumerable<Movie> GetAll();
        Movie? GetById(int id);
        int AddMovie(Movie movie);
        void DeleteMovie(int id);
        void UpdateMovie(int id,Movie movie);

    }
}
