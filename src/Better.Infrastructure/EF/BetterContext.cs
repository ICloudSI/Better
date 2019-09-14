using Better.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Better.Infrastructure.EF
{
    public class BetterContext : DbContext
    {
        private readonly SqlSettings _sqlSettings;
        public DbSet<User> Users { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Bet> Bets { get; set; }

        public BetterContext(DbContextOptions<BetterContext> options, SqlSettings sqlSettings)
            : base(options)
        {
            _sqlSettings = sqlSettings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_sqlSettings.InMemory)
            {
                optionsBuilder.UseInMemoryDatabase();

                return;
            }
            optionsBuilder.UseSqlServer(_sqlSettings.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userBuilder = modelBuilder.Entity<User>();
            userBuilder.HasKey(x => x.Id);

            modelBuilder.Entity<Match>().HasMany(x => x.Bets).WithOne();
            

        }
    }
}