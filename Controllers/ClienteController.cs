using Microsoft.AspNetCore.Mvc;

namespace mcbonaldsMvc.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}