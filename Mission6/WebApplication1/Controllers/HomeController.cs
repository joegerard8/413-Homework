using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6.Models;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MovieContext _context;

        public HomeController(MovieContext initialDB, ILogger<HomeController> logger) // Combine dependencies
        {
            _context = initialDB;
            _logger = logger;
        }

        // returns the index view
        public IActionResult Index()
        {
            return View();
        }
        //returns the about page
        public IActionResult About()
        {
            return View();
        }
        //returns the add new movie page
        public IActionResult Add()
        {
            return View();
        }
        //returns the confirmation page, which takes a Movie object as a parameter
        public IActionResult Confirmation(Movie movie)
        {
            return View(movie);
        }

        [HttpPost]
        public IActionResult Add(Movie response) //saves the movie to the database, then sends that information to the confirmation page.
        {
            _context.Movies.Add(response);
            _context.SaveChanges();

            return View("Confirmation", response);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // returns the error view
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
