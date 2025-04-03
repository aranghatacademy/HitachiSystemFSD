using Microsoft.AspNetCore.Mvc;

namespace HellpAspNet.Controllers
{
    public class AuthorsController : Controller
    {
        // GET: AuthorsController
        public ActionResult Index()
        {
            return View();
        }

    }
}
