using System;
using Microsoft.EntityFrameworkCore;
namespace Geoportal.Models
{
    public class Point
    {
        public Point()
        {
        }
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }




    }
    public class PointContext: DbContext
    {
        public DbSet<Point> Points { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=geoportal;Username=testuser;Password=0-0-0-");
        }
    }

}
