using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Domain
{
    public class User : Entity
    {
        private ISet<Bet> _bets = new HashSet<Bet>();
        public string Email { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public decimal Coins { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<Bet> Bets => _bets;

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
    }
}
