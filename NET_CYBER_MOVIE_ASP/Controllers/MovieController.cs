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
        private readonly SessionManager _session;

        public MovieController(IMovieService service, SessionManager session)
        {
            _service = service;
            _session = session;
        }
        public IActionResult Index()
        {
            return View(_service.GetAll().ToAsp());
        }

        public IActionResult Create()
        {
  
            MovieForm movie = new MovieForm();
            return View(movie);
        }


        [HttpPost]
        public IActionResult Create(MovieForm movie)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            _service.AddMovie(movie.ToDal());
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





// UserController > Contient des actions (ex edit) > avant de charger la vue, le controller va se baser sur le modèle User (il doit être communiqué au controller) > le modèle est partagé à la vue > la vue consomme les données du modèles et intègre de l'html + razor > vue passe par le moteur asp qui retourne au controller > controller renvoie la vue au naviguateur sous forme HTML



//// UserController > Contient des actions (ex edit) > avant de charger la vue, le controller va se baser sur le modèle User (il doit être communiqué au controller) > le modèle est partagé à la vue > la vue consomme les données du modèles et intègre de l'html + razor > vue passe par le moteur asp qui retourne au controller > il contacte le service afin d'exercuter une methode sur base du modele (CRUD) > controller renvoie la vue au naviguateur sous forme HTML
///

// Ajouter au MarkDown > Viewbag, viewdate, tempdata / ViewModel / remettre en forme l'explication sur le cheminement d'une action sur un site asp