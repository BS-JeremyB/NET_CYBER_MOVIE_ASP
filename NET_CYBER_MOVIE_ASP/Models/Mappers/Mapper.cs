using NET_CYBER_MOVIE_ASP.Models;

namespace Mappers
{
    public static class Mapper
    {
        // extension method to map from DAL to Model
        public static Movie ToModel(this NET_CYBER_MOVIE_ASP.DAL.Models.Movie movie)
        {
            return new Movie
            {
                Id = movie.Id,
                PosterUrl = movie.PosterUrl,
                Title = movie.Title,
                Description = movie.Description,
                Release = movie.Release,
                Score = movie.Score
            };
        }

        // extension method to map from Model to DAL
        public static NET_CYBER_MOVIE_ASP.DAL.Models.Movie ToDAL(this Movie movie)
        {
            return new NET_CYBER_MOVIE_ASP.DAL.Models.Movie
            {
                Id = movie.Id,
                PosterUrl = movie.PosterUrl,
                Title = movie.Title,
                Description = movie.Description,
                Release = movie.Release,
                Score = movie.Score
            };
        }

        //extension methode to map dal enumeration to model enumeration
        public static IEnumerable<Movie> ToModel(this IEnumerable<NET_CYBER_MOVIE_ASP.DAL.Models.Movie> movies)
        {
            List<Movie> moviesModel = new List<Movie>();
            foreach (var movie in movies)
            {
                moviesModel.Add(movie.ToModel());
            }
            return moviesModel;
        }
    }
}
