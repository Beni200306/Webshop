using WebshopMVC.Models;
namespace WebshopMVC.Data
{
    public class ProductService
    {
        WebshopDbContext ctx;
        public ProductService(WebshopDbContext context)
        {
            this.ctx = context;
        }
        public void Add(Product product)
        {
            ctx.Products.Add(product);
            ctx.SaveChanges();
        }
        public void Delete(int id)
        {
            Product? del = Read(id);
            if (del is not null)
            {
                ctx.Products.Remove(del);
            }
            ctx.SaveChanges();
        }
        public IEnumerable<Product> Read()
        {
            return ctx.Products;
        }
        public Product? Read(int id)
        {
            return ctx.Products.FirstOrDefault(x => x.Id == id);
        }
        public void Update(Product product)
        {
            Product? toUpdate = Read(product.Id);
            foreach (var prop in typeof(Product).GetProperties())
            {
                var value = prop.GetValue(product);
                prop.SetValue(toUpdate,value);
            }
            ctx.SaveChanges();
        }
    }
}
