using Microsoft.AspNetCore.Mvc;
using WebshopMVC.Data;
using WebshopMVC.Models;

namespace WebshopMVC.Controllers
{
    public class CartController:Controller
    {
        ICartService cart;
        ProductService productService;

        public CartController(ICartService cartService, ProductService ps)
        {
            this.cart = cartService;
            productService=ps;
        }
        public IActionResult Index()
        {
            return View(cart.Read());
        }
        public IActionResult Add(int id, int q)
        {
            Product p = productService.Read(id);
            CartItem item = new CartItem() {Product=p,Quantity=q, ProductId=p.Id };
            cart.Add(item);
            ;
            return RedirectToAction("Index","Home");
        }
        public IActionResult Delete(int id)
        {
            cart.Delete(id);
            return View(nameof(Index));
        }
    }
}
