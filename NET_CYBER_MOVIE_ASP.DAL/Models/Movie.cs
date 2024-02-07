using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_CYBER_MOVIE_ASP.DAL.Models
{
    public class Movie
    {
		public int Id { get; set; }
		public string PosterUrl { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime Release {  get; set; }
		public int Score { get; set; }
	}
}
