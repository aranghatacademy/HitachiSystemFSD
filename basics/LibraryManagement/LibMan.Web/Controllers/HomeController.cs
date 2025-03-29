using Microsoft.AspNetCore.Mvc;

namespace LibMan.Web.Controllers
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
