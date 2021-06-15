using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF
{
    public class BetterContext: DbContext
    {
        public BetterContext(DbContextOptions<BetterContext> options): base(options)
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Bet> Bets { get; set; }

    }
}
