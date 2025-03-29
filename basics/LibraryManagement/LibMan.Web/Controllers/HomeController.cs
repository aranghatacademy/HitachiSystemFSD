

using LibMan.Web.Db;

namespace LibMan.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookDbContext _context;

        public HomeController()
        {
            _context = new BookDbContext();
        }
        // GET: HomeController
        public ActionResult Index()
        {
            var books = _context.Books.ToList();
            return View(books);
        }

    }
}
