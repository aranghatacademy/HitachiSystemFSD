using Microsoft.AspNetCore.Mvc;

namespace api.customer.ecom.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

    }
}
