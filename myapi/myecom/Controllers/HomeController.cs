using Microsoft.AspNetCore.Mvc;


//1. I need to set up a server - windows or linux
//2. Set up the IIS or Apache or Nginx
//3. Install .NET SDK
//4. We need to configre the patah
//5. Copy the project to the server
//6. Confire the ports
namespace myecom.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
