using NET_CYBER_MOVIE_ASP.DAL.Models;

namespace DemoASPMVC_DAL.Interface
{
    public interface IUserService : IBaseRepository<User>
    {
        User Login(string username, string pwd);
        bool Register(string email, string pwd, string username);
    }
}