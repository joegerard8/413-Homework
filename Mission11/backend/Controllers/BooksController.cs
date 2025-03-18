using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


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

        [HttpGet("AllBooks")]
        public IEnumerable<Book> Get()
        {

            return _dbContext.Books;
        }
    }
}
