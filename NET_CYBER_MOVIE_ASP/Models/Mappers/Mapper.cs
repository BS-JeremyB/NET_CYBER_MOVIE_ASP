using Microsoft.CodeAnalysis.CSharp.Syntax;
using NET_CYBER_MOVIE_ASP.Models.ViewModels;
using MovieDal = NET_CYBER_MOVIE_ASP.DAL.Models.Movie;

namespace NET_CYBER_MOVIE_ASP.Models.Mappers
{
    public static class Mapper
    {


        public static Movie ToAsp(this MovieDal movie)
        {
            return new Movie
            {
                Id = movie.Id,
                PosterUrl = movie.PosterUrl,
                Title = movie.Title,
                Description = movie.Description,
                Release = movie.Release,
                Score = movie.Score,
            };
        }

        public static MovieDal ToDal(this MovieForm movie)
        {
            return new MovieDal
            {
                PosterUrl = movie.PosterUrl,
                Title = movie.Title,
                Description = movie.Description,
                Release = movie.Release,
                Score = movie.Score
            };
        }

        public static MovieForm ToForm(this MovieDal movie)
        {
            return new MovieForm
            {
                PosterUrl = movie.PosterUrl,
                Title = movie.Title,
                Description = movie.Description,
                Release = movie.Release,
                Score = movie.Score
            };
        }

        public static IEnumerable<Movie> ToAsp(this IEnumerable<MovieDal> movies)
        {
            List<Movie> movieASP = new List<Movie>();

            foreach (var item in movies)
            {
                movieASP.Add(ToAsp(item));
            }

            return movieASP;
        }

    }
}
