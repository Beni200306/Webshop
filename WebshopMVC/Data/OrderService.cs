using Microsoft.EntityFrameworkCore.Diagnostics;
using WebshopMVC.Models;

namespace WebshopMVC.Data
{
    public class OrderService
    {
        WebshopDbContext context;

        public OrderService(WebshopDbContext context)
        {
            this.context = context;
        }

        public void Add(Order order)
        {
            context.Orders.Add(order);

            context.SaveChanges();
        }
        public void AddItems(IEnumerable<OrderItem> items)
        {
            context.OrderItems.AddRange(items);
            context.SaveChanges();
        }
        public IEnumerable<Order> List()
        {
            return context.Orders;
        }

    }
}
