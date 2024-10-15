using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController(VidlyContext context) : Controller
    {
        // GET: https://localhost:7126/Controller/Action/Id
        // An action will return anything,includes a view (html/page)

        private VidlyContext _context = context;

        // https://localhost:7126/Movies
        public IActionResult Index()
        {
            //var movies = GetMovies();
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        // https://localhost:7126/Movies/Details/1
        public IActionResult Details(int id) {
            var movies = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            
            if (movies == null) { 
                return NotFound();
            }
            
            return View(movies);
        }

        // Acion to show a form to Create a new Movie
        public IActionResult New()
        {
            var viewModel = new MovieFormViewModel
            {
                Genres = _context.Genres.ToList(),
            };
            
            return View("MovieForm", viewModel);
        }

        // Action to show a from to Edit an existing Movie
        public IActionResult Edit(int id)
        {
            var movieInDB = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDB == null) 
                return NotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movieInDB,
                Genres = _context.Genres.ToList(),
            };

            return View("MovieForm", viewModel);
        }

        // This action is called when we click 'Save' button to create/edit a Movie and save it to DB
        [HttpPost]
        public IActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                // If this movie does not exist, create it
                _context.Movies.Add(movie);
            } else
            {
                // If this movie exists, get it from DB and edit it
                var movieInDB = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDB.Name = movie.Name;
                movieInDB.ReleaseDate = movie.ReleaseDate;
                movieInDB.GenreId = movie.GenreId;
                movieInDB.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction(actionName: "Index", "Movies");
        }


        // https://localhost:7126/movies/released/2024/05
        [Route("movies/released/{year}/{month:regex(\\d{{2}}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }


    }
}
