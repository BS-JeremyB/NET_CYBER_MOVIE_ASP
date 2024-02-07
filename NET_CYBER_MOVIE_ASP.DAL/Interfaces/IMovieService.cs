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
        void AddMovie(Movie movie);
        void DeleteMovie(int id);
<<<<<<< HEAD
        void UpdateMovie(int id,Movie movie);
=======
        void UpdateMovie(Movie movie);
>>>>>>> b1655f162b2c94d2ac3498296f160dea2b55221e

    }
}
