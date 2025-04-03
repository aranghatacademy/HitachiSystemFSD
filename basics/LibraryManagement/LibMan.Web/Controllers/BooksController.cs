

using LibMan.Web.Db;
using Microsoft.AspNetCore.Authorization;

namespace LibMan.Web.Controllers
{
    [Route("books")]
    [Authorize(Roles = "Admin")]
    public class BooksController : Controller
    {
        private readonly BookDbContext _context;
        private readonly ILogger<BooksController> _logger;
        private readonly ISmsService _smsService;

        //All services are injected through the constructor
        //as a dependency
        public BooksController(ILogger<BooksController> logger
                            , BookDbContext context
                            , ISmsService smsService) // To run this controller, we need a  sms service
        {
            _context = context;
            _logger = logger;
            _smsService = smsService;
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

                //var smsService = new VodafoneSMSService();
                _smsService.SendSMS("Book saved successfully: {book}", "91000000000");

                _logger.LogInformation("Book saved successfully: {book}", book);
                return RedirectToAction("Index");
            }
            
            _logger.LogWarning("Invalid book data: {book}", book);
            return View(book);
        }

    }
}
