using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class User : Entity
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public decimal Coins { get; set; }
        public DateTime CreatedAt { get; set; }

        protected User()
        {}
        public User(Guid id, string email, string username, string role, byte[] passwordHash, byte[] passwordSalt)
        {
            Id = id;
            Email = email;
            Username = username;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Role = role;
            CreatedAt = DateTime.UtcNow;
            Coins = 10;
        }
        public User(Guid id, string email, string username, string role)
        {
            Id = id;
            Email = email;
            Username = username;
            Role = role;
            CreatedAt = DateTime.UtcNow;
            Coins = 10;
        }
    }
}
