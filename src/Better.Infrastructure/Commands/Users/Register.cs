using System;
using System.ComponentModel.DataAnnotations;

namespace Better.Infrastructure.Commands.Users
{
    public class Register
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8/*, ErrorMessage = "You must specify password between 4 and  8 characters"*/)]
        public string Password { get; set; }
    }
}