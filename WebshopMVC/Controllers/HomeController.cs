using Microsoft.AspNetCore.Mvc;
using WebshopMVC.Data;

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
