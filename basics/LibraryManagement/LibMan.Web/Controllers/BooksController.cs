

using LibMan.Web.Db;

namespace LibMan.Web.Controllers
{
    [Route("books")]
    public class BooksController : Controller
    {
        private readonly BookDbContext _context;
        private readonly ILogger<BooksController> _logger;

        public BooksController(ILogger<BooksController> logger)
        {
            _context = new BookDbContext();
            _logger = logger;
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
                _logger.LogInformation("Book data is valid: {book}", book);
                _context.Books.Add(book);
                _context.SaveChanges();

                _logger.LogInformation("Book saved successfully: {book}", book);
                return RedirectToAction("Index");
            }
            
            _logger.LogWarning("Invalid book data: {book}", book);
            return View(book);
        }

    }
}
