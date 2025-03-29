

using LibMan.Web.Db;

namespace LibMan.Web.Controllers
{
    [Route("books")]
    public class BooksController : Controller
    {
        private readonly BookDbContext _context;

        public BooksController()
        {
            _context = new BookDbContext();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

    }
}
