using System;
using Microsoft.EntityFrameworkCore;
namespace Geoportal
{
    public class FileModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
    public class FileContext : DbContext
    {
        public DbSet<FileModel> Files { get; set; }
        public FileContext(DbContextOptions<FileContext> options) : base(options)
        {

        }

    }
}
