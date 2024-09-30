using Microsoft.AspNetCore.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: https://localhost:7126/Controller/Action/Id
        // An action will return anything,includes a view (html/page)

        // https://localhost:7126/Movie/Random
        public IActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };

            return View(movie);
        }

        // https://localhost:7126/Movie/Edit/1
        public IActionResult Edit(int id)
        {
            return Content("id = " + id);
        }

        // https://localhost:7126/Movie?pageIndex=2&sortBy=Date
        public IActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0} & sortBy={1}", pageIndex, sortBy));
        }
    }
}
