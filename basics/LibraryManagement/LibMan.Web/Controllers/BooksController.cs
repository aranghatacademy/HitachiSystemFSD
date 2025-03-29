using LibMan.Web.Models;
using Microsoft.AspNetCore.Mvc;

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
            
            return View(book);
        }

    }
}
