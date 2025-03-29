using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HellpAspNet.Controllers
{
    [Route("about")]
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
