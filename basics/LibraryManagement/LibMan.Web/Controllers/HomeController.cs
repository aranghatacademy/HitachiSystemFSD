

using LibMan.Web.Db;

namespace LibMan.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookDbContext _context;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger
                            , BookDbContext context)
        {
            _context = context;
            _logger = logger;
        }
        // GET: HomeController
        public ActionResult Index()
        {
            _logger.LogInformation("Index method called");
            ViewBag.Authors = _context.Books.Select(b => b.Author).Distinct().ToList();

            _logger.LogInformation("Books: {books}", _context.Books.ToList());
            var books = _context.Books.ToList();

            _logger.LogInformation("Total books: {count}", books.Count);
            return View(books);
        }

    }
}
