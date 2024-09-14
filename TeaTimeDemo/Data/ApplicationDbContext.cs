using Microsoft.EntityFrameworkCore;
using TeaTimeDemo.Models;

namespace TeaTimeDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Tea", DisplayOrder = 1 },  // Id 是整數，Name 是字符串
                new Category { Id = 2, Name = "Milk", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Coffee", DisplayOrder = 3 }
            );
        }

    }
}
