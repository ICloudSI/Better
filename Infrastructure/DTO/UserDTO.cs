﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public decimal Coins { get; set; }
        public IEnumerable<BetDTO> Bets { get; set; }
    }
}
