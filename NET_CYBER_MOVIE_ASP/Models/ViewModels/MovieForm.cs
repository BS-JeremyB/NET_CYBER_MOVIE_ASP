using System.ComponentModel.DataAnnotations;

namespace NET_CYBER_MOVIE_ASP.Models.ViewModels
{
    public class MovieForm
    {
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 5)]
        [Display(Name = "Poster")]
        public string PosterUrl { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }

        [DisplayFormat(DataFormatString ="{0: dd MMMM yyyy}",ApplyFormatInEditMode = true)]
        public DateTime Release {  get; set; }

        [Range(0, 5, ErrorMessage = "La note du film doit être entre 0 et 5")]
        public int Score { get; set; }
    }
}
