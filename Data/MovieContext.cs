using Microsoft.EntityFrameworkCore;
using MOTC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOTC.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> option): base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(c => new { c.MovieID, c.GenreID });
            modelBuilder.Entity<Favourite>().HasKey(f => new { f.MovieID, f.UserID });
            modelBuilder.Entity<Ratings>().HasKey(R => new { R.id, R.UserID, R.MovieID });
            modelBuilder.Entity<MovieCast>().HasKey(M => new { M.ActorID, M.MoviesID });
        }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Users> USers { get; set; }
        public DbSet<Actors> Actors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Directors> Directors { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<MovieCast> MovieCast { get; set; }
        public DbSet<Producers> Producers { get; set; }
        public DbSet<Ratings> Ratings { get; set; }
    }
}
