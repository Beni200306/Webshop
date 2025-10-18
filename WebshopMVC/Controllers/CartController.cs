using Microsoft.AspNetCore.Mvc;
using WebshopMVC.Data;
using WebshopMVC.Models;

namespace WebshopMVC.Controllers
{
    public class CartController : Controller
    {
        ICartService cart;
        ProductService productService;
        OrderService orderService;

        public CartController(ICartService cartService, ProductService ps, OrderService orderService)
        {
            this.cart = cartService;
            this.productService = ps;
            this.orderService = orderService;
        }
        public IActionResult Index()
        {
            IEnumerable<CartItem> c = cart.Read();
            if (c.Count() == 0)
            {
                return RedirectToAction(nameof(Empty));
            }
            return View(c);
        }
        public IActionResult Empty()
        {
            return View();
        }
        public IActionResult Add(int id, int q)
        {

            CartItem item = cart.ReadById(id);
            if (item is null)
            {
                Product? p = productService.Read(id);
                item = new CartItem() { Product = p, Quantity = q, ProductId = p.Id };
                cart.Add(item);
            }
            else
            {
                item.Quantity += q;
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Delete(int id)
        {
            cart.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(string name, string address, int phonenumber)
        {

            Order order = new Order()
            {
                Address = address,
                CustomerName = name,
                PhoneNumber = phonenumber,
                OrderDate = DateTime.Now
            };
            orderService.Add(order);

            IEnumerable<OrderItem> orderItems = cart.Read().Select(
                x => new OrderItem() {
                    OrderId=order.Id,
                    ProductId=x.ProductId,
                    Quantity=x.Quantity
                });
            
            orderService.AddItems(orderItems);
            ;

            return View();
        }
    }
}
