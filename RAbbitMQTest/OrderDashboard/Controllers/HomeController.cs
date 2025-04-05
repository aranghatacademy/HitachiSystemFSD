using Microsoft.AspNetCore.Mvc;

namespace OrderDashboard.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

    }
}
