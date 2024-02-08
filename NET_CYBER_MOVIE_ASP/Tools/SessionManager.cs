using NET_CYBER_MOVIE_ASP.Models;
using Newtonsoft.Json;

namespace NET_CYBER_MOVIE_ASP.Tools
{
    public class SessionManager
    {

        private readonly ISession _session;

        public SessionManager(IHttpContextAccessor httpContext)
        {
            _session = httpContext.HttpContext.Session;
        }

        public User? ConnectedUser
        {
            get
            {
                return
                    (string.IsNullOrEmpty(_session.GetString("connectedUser"))) ?
                    null :
                    JsonConvert.DeserializeObject<User>(_session.GetString("connectedUser"));
            }
            set
            {
                _session.SetString("connectedUser", JsonConvert.SerializeObject(value));
            }
        }

        void logout()
        {
            _session.Clear();
        }

    }
}
