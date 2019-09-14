using System;

namespace Better.Infrastructure.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public decimal Coins { get; set; }


    }
}