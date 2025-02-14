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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

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
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
