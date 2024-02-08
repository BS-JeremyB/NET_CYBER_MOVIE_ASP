using Microsoft.AspNetCore.Mvc;
using NET_CYBER_MOVIE_ASP.DAL.Interfaces;
using NET_CYBER_MOVIE_ASP.Models;
using NET_CYBER_MOVIE_ASP.Models.Mappers;
using NET_CYBER_MOVIE_ASP.Models.ViewModels;
using NET_CYBER_MOVIE_ASP.Tools;

namespace NET_CYBER_MOVIE_ASP.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;
        private readonly SessionManager _session;

        public UserController(IUserService service, SessionManager session)
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
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public IActionResult Create(User user) 
        {
            _service.Create(user.ToDal());
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            
            return View(_service.GetById(id).ToAsp());
        }


        public IActionResult Login()
        {

            return View(new LoginForm());
        }


        [HttpPost]
        public IActionResult Login(LoginForm loginForm)
        {
            User user = _service.login(loginForm.Username, loginForm.Password).ToAsp();
            _session.ConnectedUser = user;
            return RedirectToAction("Index");
            
        }
    }
}
