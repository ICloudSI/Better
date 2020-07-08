using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class User : Entity
    {
        public string Email { get; protected set; }
        public string Username { get; protected set; }
        public string FullName { get; protected set; }
        public string Role { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public decimal Coins { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        public User(Guid id, string email, string username, string role, string password, string salt)
        {
            Id = id;
            Email = email;
            Username = username;
            Password = password;
            Salt = salt;
            Role = role;
            CreatedAt = DateTime.UtcNow;
            Coins = 10;
        }
    }
}
