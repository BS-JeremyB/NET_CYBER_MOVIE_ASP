using Microsoft.AspNetCore.Mvc;
using NET_CYBER_MOVIE_ASP.DAL.Interfaces;
using NET_CYBER_MOVIE_ASP.Models;
using NET_CYBER_MOVIE_ASP.Models.Mappers;
using NET_CYBER_MOVIE_ASP.Models.ViewModels;
using NET_CYBER_MOVIE_ASP.Tools;

namespace NET_CYBER_MOVIE_ASP.Controllers
{
    public class MovieController : Controller
    {

        private readonly IMovieService _service;
        private readonly IUserMoviesService _userMov;
        private readonly SessionManager _session;

        public MovieController(IMovieService service, SessionManager session, IUserMoviesService userMov)
        {
            _service = service;
            _session = session;
            _userMov = userMov;

        }
        public IActionResult Index()
        {
            return View(_service.GetAll().ToAsp());
        }

        [CustomAuthorize]
        public IActionResult Create()
        {
  
            MovieForm movie = new MovieForm();
            return View(movie);
        }

        [CustomAuthorize]
        [HttpPost]
        public IActionResult Create(MovieForm movie)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }


            if (!_service.IfExist(movie.ToDal()))
            {
                Movie movieWithId = _service.AddMovie(movie.ToDal()).ToAsp();
                _userMov.AddFavourite(_session.ConnectedUser.Id, movieWithId.Id);
                return RedirectToAction("Details","Movie", new {movieWithId.Id});
            }

            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {
            Movie? movie = _service.GetById(id).ToAsp();
            if (movie is not null)
            {
                return View(movie);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            TempData["movieId"] = id;
            MovieForm? movie = _service.GetById(id).ToForm();
            if (movie is not null)
            {
                return View(movie);
            }
            return RedirectToAction("Index");
        }


        [HttpPost]

        public IActionResult Edit(MovieForm movie)
        {

            _service.UpdateMovie((int)TempData["movieId"],movie.ToDal());
            return RedirectToAction("Index");
        }

        [CustomAuthorize]
        public IActionResult Delete(int id)
        {
            _service.DeleteMovie(id);
            return RedirectToAction("Index");
        }



    }
}
