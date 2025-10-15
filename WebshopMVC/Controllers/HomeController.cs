using Microsoft.AspNetCore.Mvc;
using WebshopMVC.Data;
using WebshopMVC.Models;

namespace WebshopMVC.Controllers
{
    public class HomeController:Controller
    {
        ProductService productService;
        ICartService cart;
        public HomeController(ProductService ps,ICartService cart)
        {
            this.productService = ps;
            this.cart = cart;
        }

        public IActionResult Index()
        {
            return View(productService.Read());
        }

        public IActionResult AddCart(int id, int q)
        {
            Product prod = productService.Read(id);
            CartItem item = new CartItem() {Product=prod, ProductId=prod.Id, Quantity=q };
            cart.Add(item);
            return RedirectToAction(nameof(Index));
        }

    }
}
