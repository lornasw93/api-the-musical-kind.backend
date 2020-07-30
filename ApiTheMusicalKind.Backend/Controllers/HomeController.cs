using Microsoft.AspNetCore.Mvc;

namespace ApiTheMusicalKind.Backend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
