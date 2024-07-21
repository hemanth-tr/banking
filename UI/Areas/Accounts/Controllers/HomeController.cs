using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Accounts.Controllers
{
    [Area("accounts")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
