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
        // This page shows a form to create a new customer
        public IActionResult New()
        {
            // We use ViewModel so we can access to 2 models (Customer + MembershipType)
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View(viewModel);
        }

        // This action is called when we click 'Save' button to create a new customer and save it to DB
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction(actionName: "Index", controllerName: "Customers");
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
