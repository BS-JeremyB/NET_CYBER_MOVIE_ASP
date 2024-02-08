using Microsoft.AspNetCore.Mvc;
using NET_CYBER_MOVIE_ASP.Tools;

namespace NET_CYBER_MOVIE_ASP.Controllers
{
    public class FavorisController : Controller
    {

        private readonly SessionManager _session;

        public FavorisController(SessionManager session)
        {
            _session = session;
        }

        [CustomAuthorize]
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
