using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;


namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private AppDbContext _dbContext;
        public BooksController(AppDbContext temp)
        {
            _dbContext = temp;
        }
        [HttpGet("SomeBooks")]
        public IActionResult GetBooks(int pageSize = 5, int page = 1)
        {
            // logging the cookie for 414
            string? favoriteBook = Request.Cookies["BookType"];
            Console.WriteLine("~~~~~COOKIE~~~~~~~" + favoriteBook);

            // setting cookies for 414
            HttpContext.Response.Cookies.Append("BookType", "Fiction", new CookieOptions()
            {
                HttpOnly = true,
                Secure = true, // Fixed the syntax error here
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.Now.AddMinutes(1)
            });

            var books = _dbContext.Books
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToList();

            var totalCount = _dbContext.Books.Count();

            var response = new
            {
                Books = books,
                Count = totalCount
            };

            return Ok(response);
        }


        [HttpGet("AllBooks")]
        public IEnumerable<Book> Get()
        {

            return _dbContext.Books;
        }
    }
}
