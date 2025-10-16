using Microsoft.AspNetCore.Mvc;
using WebshopMVC.Data;
using WebshopMVC.Models;

namespace WebshopMVC.Controllers
{
    public class HomeController:Controller
    {
        ProductService productService;
        public HomeController(ProductService ps)
        {
            this.productService = ps;
        }

        public IActionResult Index()
        {
            return View(productService.Read());
        }

        

    }
}
