using Microsoft.AspNetCore.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: https://localhost:7126/Controller/Action/Id
        // An action will return anything,includes a view (html/page)

        // https://localhost:7126/Movies/Random
        public IActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };

            return View(movie);
        }

        // https://localhost:7126/Movies/Edit/1
        public IActionResult Edit(int id)
        {
            return Content("id = " + id);
        }

        // https://localhost:7126/Movies?pageIndex=2&sortBy=Date
        public IActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0} & sortBy={1}", pageIndex, sortBy));
        }
        
        // https://localhost:7126/movies/released/2024/05
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}
