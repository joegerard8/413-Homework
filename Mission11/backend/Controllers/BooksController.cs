﻿using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
// full backend controller for getting books, categories and filtering them

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
        // setting the parameters, as well as their default values if nothing is passed. 
        // was having touble getting the query string, so I passed the fromquery to the categories to help it
        public IActionResult GetBooks(int pageSize = 5, int page = 1, int sorted = 1, [FromQuery] List<string>? categories = null)
        {
            // Initialize the queryable object from the DbSet
            var query = _dbContext.Books.AsQueryable();

            // Filter by categories if they are passed from the frontend
            if (categories != null && categories.Count > 0)
            {
                query = query.Where(b => categories.Contains(b.Category));
            }

            // Log the cookie value for debugging (optional)
            string? favoriteBook = Request.Cookies["BookType"];
            Console.WriteLine("~~~~~COOKIE~~~~~~~ " + favoriteBook);

            // Set a cookie for 414
            HttpContext.Response.Cookies.Append("BookType", "Fiction", new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.Now.AddMinutes(1)
            });

            // Apply sorting if requested from the frontend
            if (sorted == 1)
            {
                query = query.OrderBy(b => b.Title); // Sort alphabetically by title
            }

            // Get the total count of books after filtering
            var totalCount = query.Count();

            // Apply pagination
            var books = query
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToList();

            // Create the response object
            var response = new
            {
                Books = books,
                Count = totalCount
            };

            // Return the response with a 200 OK status
            return Ok(response);
        }



        [HttpGet("AllBooks")]
        // getting all the books with no filters or anything
        public IEnumerable<Book> Get()
        {

            return _dbContext.Books;
        }

        [HttpGet("GetBookCategories")]

        public IActionResult GetBookCategories() 
        {
            var categories = _dbContext.Books.Select(b => b.Category).Distinct().ToList(); // selecting just book categories and making them distinct
            return Ok(categories); // returning the 200 and the cateogires
        }
    }
}
