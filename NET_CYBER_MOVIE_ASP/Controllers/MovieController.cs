using DemoASPMVC_DAL.Interface;
using Mappers;
using Microsoft.AspNetCore.Mvc;
using NET_CYBER_MOVIE_ASP.DAL.Interfaces;
using NET_CYBER_MOVIE_ASP.DAL.Models;
using NET_CYBER_MOVIE_ASP.DAL.Services;

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
            return View(_service.GetAll(nameof(Movie)).ToModel());
        }

        public IActionResult Create()
        {
            Movie movie = new Movie();
            return View(movie.ToModel());
        }


        [HttpPost]
        public IActionResult Create(Movie movie) 
        {
            _service.AddMovie(movie);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(_service.GetById(nameof(Movie),id).ToModel());
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            _service.UpdateMovie(movie);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _service.Delete(nameof(Movie),id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(_service.GetById(nameof(Movie),id).ToModel());
        }
    }
}
