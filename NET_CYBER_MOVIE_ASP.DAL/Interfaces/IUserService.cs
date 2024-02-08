using NET_CYBER_MOVIE_ASP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_CYBER_MOVIE_ASP.DAL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User? GetById(int id);
        void Update(User user);
        void Delete(int id);
        void Create(User user);
        User? login(string username, string password);
    }
}
