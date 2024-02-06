using DemoASPMVC_DAL.Interface;
using NET_CYBER_MOVIE_ASP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_CYBER_MOVIE_ASP.DAL.Interfaces
{
    public interface IMovieService : IBaseRepository<Movie>
    {


        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        IEnumerable<Movie> GetByUserId(int userId);
        void AddFavorite(int idUser, int idMovie);

    }
}
