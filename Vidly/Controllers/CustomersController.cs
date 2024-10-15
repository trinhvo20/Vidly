using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // Make connection the Vidly database through VidlyContext
        private VidlyContext _context;

        public CustomersController(VidlyContext context)
        {
            _context = context;
        }

        // https://localhost:7126/Customers
        public IActionResult Index()
        {
            //var customers = GetCustomers();
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        // https://localhost:7126/Customers/Details/1
        public IActionResult Details(int id) 
        {
            //var customers = GetCustomers().SingleOrDefault(c => c.Id == id);
            var customers = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customers == null) 
                return NotFound();
            
            return View(customers);
        }

        // https://localhost:7126/Customers/New
        public IActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View(viewModel);
        }

        // Methods that used before we have database to getCustomer list
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }
    }
}
