using Microsoft.AspNetCore.Mvc;
using LibMan.Web.Db;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
namespace LibMan.Web.Controllers
{
    [Route("auth")]
    public class LoginController : Controller
    {
        private readonly BookDbContext _context;
        private readonly ILogger<LoginController> _logger;
        private readonly ISmsService _smsService;   
        public LoginController(BookDbContext context, ILogger<LoginController> logger, ISmsService smsService)
        {
            _context = context;
            _logger = logger;
            _smsService = smsService;
        }
        // GET: LoginController
        [HttpGet]
        [Route("login")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Index(string txtEmail, string txtPassword)
        {
            bool isAuthenticated = false;
            var user = _context.Admins.FirstOrDefault(u => u.Email == txtEmail && u.Password == txtPassword);
            _logger.LogInformation("User: {Email} {Password}", txtEmail, txtPassword);
            List<Claim> claims = new List<Claim>();
            if(user !=null)
            {
                isAuthenticated = true;
                claims = GetClaims(user, "Admin");
            }
            else
            {
                //Try to login the user amoung members
                var member = _context.Members.FirstOrDefault(u => u.Email == txtEmail && u.Password == txtPassword);
                if(member != null)
                {
                    _smsService.SendSMS("You have logged in from a new device", member.PhoneNumber);
                    isAuthenticated = true;
                    claims = GetClaims(member, "Member");
                }

            }

            if(!isAuthenticated)
            {
                //var smsService = new VodafoneSMSService();
                
                ViewBag.Error = "Invalid email or password";
            }
            else
            {
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(principal);
                return Redirect("/");
            }

            return View();
        
    }

        [HttpGet]
        [Route("logout")]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        private List<Claim> GetClaims(User user, string role)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Name));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.Role, role));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            return claims;
        }
}
}
