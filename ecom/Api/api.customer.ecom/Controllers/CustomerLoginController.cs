using Microsoft.AspNetCore.Mvc;

namespace api.customer.ecom.Controllers
{
    [Route("customer/login")]
    public class CustomerLoginController : Controller
    {
        // GET: CustomerLoginController
        public ActionResult Index()
        {
            return View();
        }

    }
}
