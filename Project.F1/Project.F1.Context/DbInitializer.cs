using Microsoft.EntityFrameworkCore;
using Project.F1.Models;
using System;

namespace Project.F1.Context
{
    public class DbInitializer : DbContext
    {

        public DbSet<Track> Tracks { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Constructor> Constructors { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = ProjectF1Data");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
