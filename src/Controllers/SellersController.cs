using Microsoft.AspNetCore.Mvc;

namespace src.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index() => View();
    }
}