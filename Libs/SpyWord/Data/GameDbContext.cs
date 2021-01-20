using Microsoft.EntityFrameworkCore;
using SpyWord.Data.Entities;

namespace SpyWord.Data
{
    public class GameDbContext: DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }

        public GameDbContext(DbContextOptions<GameDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Game>().HasKey(g => g.Id);
            builder.Entity<Game>().Ignore(c => c.Cards);
            builder.Entity<Game>().Ignore(c => c.Players);



            builder.Entity<Player>()
                .HasKey(p => p.Id);
        }

    }
}
