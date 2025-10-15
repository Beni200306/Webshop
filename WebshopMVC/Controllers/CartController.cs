using Microsoft.AspNetCore.Mvc;
using WebshopMVC.Data;
using WebshopMVC.Models;

namespace WebshopMVC.Controllers
{
    public class CartController:Controller
    {
        ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }
        public IActionResult Index()
        {
            return View(cartService.Read());
        }
        public IActionResult Add(CartItem item)
        {
            cartService.Add(item);
            return View(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            cartService.Delete(id);
            return View(nameof(Index));
        }
    }
}
