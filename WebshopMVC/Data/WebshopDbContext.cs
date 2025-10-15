using Microsoft.EntityFrameworkCore;
using WebshopMVC.Models;

namespace WebshopMVC.Data
{
    public class WebshopDbContext : DbContext
    {
        public WebshopDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();

            Products?.Add(new Product() {Name="Alma",
                    Description="Finom, nagyon finom piros",
                    Price=1200,
            ImageURL="asd"});
            Products?.Add(new Product() {Name="Banán",
                    Description="Finom, nagyon finom sárga",
                    Price=1000,
                ImageURL = "asd"
            });
            Products?.Add(new Product()
            {
                Name = "Meggy",
                Description = "Finom, nagyon finom vörös",
                Price = 2200,
                ImageURL = "asd"
            });

            this.SaveChanges();
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<OrderItem> OrderItems{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Webshop;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
