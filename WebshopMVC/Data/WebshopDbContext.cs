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
            Products.Add(new Product() { Name="alma", Description="piros, finom",Price=2000,ImageURL="asd" });
            Products.Add(new Product() { Name="meggy", Description="vörös, finom",Price=2200, ImageURL = "asd" });
            Products.Add(new Product() { Name="banán", Description="sárga, még finomabb",Price=1200, ImageURL = "asd" });
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
