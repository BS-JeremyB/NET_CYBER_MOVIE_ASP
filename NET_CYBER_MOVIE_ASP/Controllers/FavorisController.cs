using Microsoft.AspNetCore.Mvc;
using NET_CYBER_MOVIE_ASP.DAL.Interfaces;
using NET_CYBER_MOVIE_ASP.Models;
using NET_CYBER_MOVIE_ASP.Models.Mappers;
using NET_CYBER_MOVIE_ASP.Tools;

namespace NET_CYBER_MOVIE_ASP.Controllers
{
    public class FavorisController : Controller
    {

        private readonly SessionManager _session;
        private readonly IUserMoviesService _service;

        public FavorisController(SessionManager session, IUserMoviesService service)
        {
            _session = session;
            _service = service;
        }

        [CustomAuthorize]
        public IActionResult Index()
        {
            IEnumerable<Movie> movies = _service.GetAllByUser(_session.ConnectedUser.Id).ToAsp();
            return View(movies);
        }
    }
}
