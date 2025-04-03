using Microsoft.AspNetCore.Mvc;
using LibMan.Web.Db;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
namespace LibMan.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly BookDbContext _context;
        private readonly ILogger<LoginController> _logger;
        public LoginController(BookDbContext context, ILogger<LoginController> logger)
        {
            _context = context;
            _logger = logger;
        }
        // GET: LoginController
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(string Email, string Password)
        {
            var user = _context.Admins.FirstOrDefault(u => u.Email == Email && u.Password == Password);
            _logger.LogInformation("User: {Email} {Password}", Email, Password);
            if(user !=null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                };
                
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(principal);
                return Redirect("/");

            }

            ViewBag.Error = "Invalid email or password";

            return View();
        }
    }
}
