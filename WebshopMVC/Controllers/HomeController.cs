using Microsoft.AspNetCore.Mvc;

namespace WebshopMVC.Controllers
{
    public class HomeController:Controller
    {
        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
