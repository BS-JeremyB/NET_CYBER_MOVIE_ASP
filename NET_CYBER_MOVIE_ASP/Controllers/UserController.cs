using Microsoft.AspNetCore.Mvc;
using NET_CYBER_MOVIE_ASP.DAL.Interfaces;
using NET_CYBER_MOVIE_ASP.Models;
using NET_CYBER_MOVIE_ASP.Models.Mappers;

namespace NET_CYBER_MOVIE_ASP.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
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
    }
}
