using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeaTimeDemo.Models;

namespace TeaTimeDemo.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Tea", DisplayOrder = 1 },  // Id 是整數，Name 是字符串
                new Category { Id = 2, Name = "Milk", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Coffee", DisplayOrder = 3 }
            );
            //modelBuilder.Entity<Product>().ToTable("Products"); // 将表名指定为复数形式
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "水果茶",
                    Size = "大杯",
                    Description = "酸甜",
                    Price = 60,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 2,
                    Name = "铁观音",
                    Size = "中杯",
                    Description = "茶香",
                    Price = 50,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 3,
                    Name = "冰美式",
                    Size = "大杯",
                    Description = "苦涩",
                    Price = 40,
                    CategoryId = 3,
                    ImageUrl = ""
                }
            );
            modelBuilder.Entity<Store>().HasData(
                new Store { 
                    Id = 1,
                    Name = "台中一中店",
                    Address ="台中市北区三民路三段129号",
                    City = "台中市",
                    PhoneNumber = "0987654321",
                    Description = "临近一中商圈"
                },
                new Store
                {
                    Id = 2,
                    Name = "台北信义店",
                    Address = "台北市信义区信义路一段9号",
                    City = "台北市",
                    PhoneNumber = "0912345678",
                    Description = "临近信义商圈"
                },
                new Store
                {
                    Id=3,
                    Name = "高雄五福店",
                    Address = "高雄市新兴区五福三路13号",
                    City = "高雄市",
                    PhoneNumber = "0912348765",
                    Description = "临近新崛江商圈"
                }
                );
        }

    }
}
