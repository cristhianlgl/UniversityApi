using ApiOpenUniversity.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiOpenUniversity.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Chapter>? Chapters { get; set; }
        public DbSet<Student>? Students { get; set; }

    }
}
