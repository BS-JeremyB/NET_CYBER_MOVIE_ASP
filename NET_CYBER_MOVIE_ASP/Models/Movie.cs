namespace NET_CYBER_MOVIE_ASP.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string PosterUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Release { get; set; }
        public int Score { get; set; }
    }
}
