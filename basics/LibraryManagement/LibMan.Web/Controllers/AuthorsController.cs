using Microsoft.AspNetCore.Mvc;
using LibMan.Web.Db;
namespace LibMan.Web.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly BookDbContext _context;
        private readonly ILogger<AuthorsController> _logger;
        public AuthorsController(BookDbContext context, ILogger<AuthorsController> logger)
        {
            _context = context;
            _logger = logger;
        }
        // GET: AuthorsController
        [HttpGet("{author}")]
        public ActionResult Index(string author)
        {
            var books = _context.Books.Where(b => b.Author == author).ToList();
            return View(books);
        }

    }
}
