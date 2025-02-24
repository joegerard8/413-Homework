using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.Categories = _context.Categories.ToList();
            return View(new Movie()); // passing a pre built movie object so that the application id is not null
        }
        //returns the confirmation page, which takes a Movie object as a parameter
        public IActionResult Confirmation(Movie movie) // takes the user to the confirmation page, and passes the movie object to display information about the newly created Movie record
        {
            return View(movie);
        }

        [HttpPost]
        public IActionResult Add(Movie response) //saves the movie to the database, then sends that information to the confirmation page.
        {
            if (ModelState.IsValid) //checking if the movie object has everything it needs
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
                return View("Confirmation", response);
            }
            else // if there is invalid data
            {
                ViewBag.Categories = _context.Categories.ToList(); // passing the view bag when returning to the add page with the errrors
                return View(response); //returning the data back to them.
            }
        }

        public IActionResult MovieCollection() // Movie collection action, returns the moviecollection view with all of the movies from the database
        {

            var movies = _context.Movies
                .Include(m => m.Category) //includes the categories to also display the category names in the table
                .ToList(); // pulling from the database, gets an array of all the movies in the database/

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id) // edit action, getting the values to populate the field.
        {
            Console.WriteLine(id);
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id); // use the command .Single to get just a single record instead of .Where

            ViewBag.Categories = _context.Categories.ToList(); //getting all of the differrent movie categories to populate the drop down on the aplication. 

            return View("Add", recordToEdit);
            // can do RedirectToAction to a certain action if you want. 
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedMovie) // actually posting the updated values to the database. 
        {
            _context.Update(updatedMovie);
            _context.SaveChanges();

            return RedirectToAction("MovieCollection"); // this is used because if we used return View(), it would just take us to the view without any data. We need to route to the action to get all the data and the complete view
        }

        [HttpGet]
        public IActionResult Delete(int id) //Delete action, pulls up the delete view and passes the movie that is going to be deleted. uses that to show the title etc. to the user and ask for a confirmation
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie) //action to actually delete the record. removes the record from the context and saves the changes, then re routes to the movie collection page
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("MovieCollection");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // returns the error view
        public IActionResult Error() //error action
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
