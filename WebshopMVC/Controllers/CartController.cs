using Microsoft.AspNetCore.Mvc;
using WebshopMVC.Data;

namespace WebshopMVC.Controllers
{
    public class CartController:Controller
    {
        ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

    }
}
