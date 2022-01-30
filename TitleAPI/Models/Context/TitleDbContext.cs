using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace TitleAPI.Models.Context
{
    [ExcludeFromCodeCoverage]
    public class TitleDbContext : DbContext
    {
        public TitleDbContext(DbContextOptions<TitleDbContext> options) : base(options)
        {

        }

        public DbSet<Title> Title { get; set; }
        public DbSet<Genre> Genre { get; set; }

        public DbSet<TitleGenre> TitleGenre { get; set; }

        public DbSet<TitleParticipant> TitleParticipant { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Title>()
            .HasMany(c => c.TitleGenres)
            .WithOne(e => e.Title);

            modelBuilder.Entity<Title>()
           .HasMany(c => c.Awards)
           .WithOne(e => e.Title);

            modelBuilder.Entity<Title>()
           .HasMany(c => c.StoryLines)
           .WithOne(e => e.Title);

            modelBuilder.Entity<Title>()
          .HasMany(c => c.OtherNames)
          .WithOne(e => e.Title);

            modelBuilder.Entity<Title>()
           .HasMany(c => c.TitleParticipants)
           .WithOne(e => e.Title);

            modelBuilder.Entity<Genre>()
           .HasMany(c => c.TitleGenres)
           .WithOne(e => e.Genre);

            modelBuilder.Entity<Participant>()
           .HasMany(c => c.TitleParticipants)
           .WithOne(e => e.Participant);
        }
    }
}
