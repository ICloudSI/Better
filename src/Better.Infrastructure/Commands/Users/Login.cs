using System.ComponentModel.DataAnnotations;

namespace Better.Infrastructure.Commands.Users
{
    public class Login
    {

        public string Email { get; set; }

        public string Password { get; set; }
    }
}