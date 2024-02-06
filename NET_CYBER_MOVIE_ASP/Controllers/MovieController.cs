using Microsoft.AspNetCore.Mvc;
using NET_CYBER_MOVIE_ASP.DAL.Interfaces;
using NET_CYBER_MOVIE_ASP.DAL.Models;

namespace NET_CYBER_MOVIE_ASP.Controllers
{
    public class MovieController : Controller
    {

        private readonly IMovieService _service;

        public MovieController(IMovieService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            Movie movie = new Movie();
            return View(movie);
        }


        [HttpPost]
        public IActionResult Create(Movie movie) 
        {
            _service.AddMovie(movie);
            return RedirectToAction("Index");
        }
    }
}
