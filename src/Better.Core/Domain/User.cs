using System;

namespace Better.Core.Domain
{
    public class User : Enity
    {
        public string Email { get; protected set; }
        public string Username { get; protected set; }
        public string FullName { get; protected set; }
        public string Role { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public decimal Coins { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected User()
        {
        }

        public User(Guid id, string email, string username, string role, string password, string salt)
        {
            Id = id;
            SetEmail(email);
            SetUsername(username);
            SetPassword(password, salt);
            Role = role;
            CreatedAt = DateTime.UtcNow;
            Coins = 10;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email can not be empty.");
            }
            if (!email.Contains('@'))
            {
                throw new Exception("Wrong email");
            }
            if (Email == email)
            {
                return;
            }
            Email = email.ToLowerInvariant();
        }

        public void SetUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new Exception("Username is walid");
            }

            Username = username;
        }

        public void SetPassword(string password, string salt)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password can not be empty.");
            }
            if (string.IsNullOrWhiteSpace(salt))
            {
                throw new Exception("Salt cann not be empty.");
            }

            if (password.Length < 4)
            {
                throw new Exception("Password must contain at least 4 characters.");
            }
            if (password.Length > 100)
            {
                throw new Exception("Password can not contain more than 100 characters.");
            }
            if (Password == password)
            {
                return;
            }
            Password = password;
            Salt = salt;
        }

        public void AddCoins(decimal coins)
        {
            if (coins < 0)
            {
                throw new Exception("Can not add less 0");
            }
            Coins += coins;
        }

        public void SubstractCoins(decimal coins)
        {
            if (coins < 0)
            {
                throw new Exception("Can not substract more than 0");
            }
            Coins -= coins;
        }


    }
}