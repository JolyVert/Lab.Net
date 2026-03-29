using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Net_Lab2.Data;

public sealed class MovieDbContext : DbContext
{
    public DbSet<MovieEntity> Movies => Set<MovieEntity>();
    public DbSet<GenreEntity> Genres => Set<GenreEntity>();
    public DbSet<MovieGenreEntity> MovieGenres => Set<MovieGenreEntity>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=movies.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MovieEntity>()
            .HasIndex(m => m.TmdbId)
            .IsUnique();

        modelBuilder.Entity<MovieGenreEntity>()
            .HasKey(x => new { x.MovieEntityId, x.GenreEntityId });

        modelBuilder.Entity<MovieGenreEntity>()
            .HasOne(x => x.Movie)
            .WithMany(x => x.MovieGenres)
            .HasForeignKey(x => x.MovieEntityId);

        modelBuilder.Entity<MovieGenreEntity>()
            .HasOne(x => x.Genre)
            .WithMany(x => x.MovieGenres)
            .HasForeignKey(x => x.GenreEntityId);
    }
}
