using CatchMore.Models;
using Microsoft.EntityFrameworkCore;

namespace CatchMore.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //DB Tables
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Catch> Catches { get; set; }

        //DB Seed Data
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Session>().HasData(
        //        new Session { Id = 10, Date = DateTime.Now, Latitude = 51.98807, Longitude = 6.004520 },
        //        new Session { Id = 11, Date = DateTime.Now, Latitude = 52.98807, Longitude = 6.204520 }
        //        );

        //    modelBuilder.Entity<Catch>().HasData(

        //        new Catch() { Id = 2, Date = DateTime.Now, Species = "Perch", Weight = 2, Length = 50, SessionId = 10, Image = ""},
        //        new Catch() { Id = 3, Date = DateTime.Now, Species = "Perch", Weight = 1.5, Length = 45, SessionId = 11, Image = "" }
        //        );
        //}
    }
}
