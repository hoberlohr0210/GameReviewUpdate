using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GameReviewUpdate.Models;
using GameReview.Models;

namespace GameReviewUpdate.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<GameType> Types { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }
        public DbSet<ReviewGame> Reviews { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GameGenre>()
                .HasKey(g => new { g.GameID, g.GenreID });
        }
    }
}
