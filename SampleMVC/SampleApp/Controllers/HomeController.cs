using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleApp.Db;
using SampleApp.Model;

namespace SampleApp.Controllers
{
 
    public class HomeController : Controller
    {
        private readonly SampleDbContext _context;
        private int RoleId = 1;

        public HomeController()
        {
            _context = new SampleDbContext();
        }

        // GET: HomeController
        [HttpGet]
        public ActionResult Index()
        {
            var userRoles = _context.UserRoles.Include(r => r.Menus);
            if(HttpContext.User.IsInRole("Admin"))
            //if(RoleId == 1)
            {
                ViewBag.Menus = userRoles.FirstOrDefault(d => d.Id == 1).Menus;
            }
            else
            {
                ViewBag.Menus = userRoles.FirstOrDefault(d => d.Id == 2).Menus;
            }

            ViewBag.States = _context.States.ToList();
            return View();
        }

        [HttpGet("get-departments")]
        public JsonResult GetDepartments(int stateId)
        {
            var departments = _context.States.Include(s => s.Departments).First(d => d.Id == stateId).Departments;
            return Json(departments);
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            user.RegistrationNumber = Guid.NewGuid().ToString();
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
