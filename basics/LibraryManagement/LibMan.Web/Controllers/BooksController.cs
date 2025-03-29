

namespace LibMan.Web.Controllers
{
    [Route("books")]
    public class BooksController : Controller
    {
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
                //ToDo : Save this book to the database
            }
            return View(book);
        }

    }
}
