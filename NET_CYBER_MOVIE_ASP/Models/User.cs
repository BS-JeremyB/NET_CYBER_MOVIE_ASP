using Humanizer;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.ComponentModel;

namespace NET_CYBER_MOVIE_ASP.Models
{
    public class User
    {
 
        public int Id { get; set; }
        public string Username { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }

       
        public string Password { get; set; }

    }
}
