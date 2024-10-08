using Microsoft.AspNetCore.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // https://localhost:7126/Customers
        public IActionResult Index()
        {
            var customers = GetCustomers();

            return View(customers);
        }

        // https://localhost:7126/Customers/Details/1
        public IActionResult Details(string id) 
        {
            var customers = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customers == null) 
                return NotFound();
            
            return View(customers);
        }

        // Methods
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = "1", Name = "John Smith" },
                new Customer { Id = "2", Name = "Mary Williams" }
            };
        }
    }
}
