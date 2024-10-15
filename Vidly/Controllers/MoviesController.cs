using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: https://localhost:7126/Controller/Action/Id
        // An action will return anything,includes a view (html/page)

        private VidlyContext _context;

        public MoviesController(VidlyContext context)
        {
            _context = context;
        }

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

        // https://localhost:7126/Movies/Random
        //public IActionResult Random()
        //{
        //    var movie = new Movie() { Name = "Shrek" };
        //    var customers = new List<Customer>
        //    {
        //        new Customer { Name = "Customer 1" },
        //        new Customer { Name = "Customer 2" },
        //    };

        //    var viewModel = new RandomMovieViewModel 
        //    { 
        //        Movie = movie,
        //        Customers = customers
        //    };

        //    return View(viewModel);
        //}

        // Methods
        //private IEnumerable<Movie> GetMovies()
        //{
        //    return new List<Movie>
        //    {
        //        new Movie { Id = 1, Name = "Shrek" },
        //        new Movie { Id = 2, Name = "Wall-e" }
        //    };
        //}

        //  BELOW THIS LINE IS PRACTCE CREATING ACTIONS =========================================================
        // https://localhost:7126/Movies/Edit/1
        public IActionResult Edit(int id)
        {
            return Content("id = " + id);
        }

        // https://localhost:7126/Movies?pageIndex=2&sortBy=Date
        //public IActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(String.Format("pageIndex={0} & sortBy={1}", pageIndex, sortBy));
        //}

        // https://localhost:7126/movies/released/2024/05
        [Route("movies/released/{year}/{month:regex(\\d{{2}}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}
