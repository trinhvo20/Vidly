﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController(VidlyContext context) : Controller
    {
        // Make connection the Vidly database through VidlyContext
        private VidlyContext _context = context;

        // https://localhost:7126/Customers
        public IActionResult Index()
        {
            return View();
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
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        public IActionResult Edit(int id) {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            
            return View("CustomerForm", viewModel);
        }

        // This action is called when we click 'Save' button to create/edit a customer and save it to DB
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                // if form validation fails, return to CustomerForm (the same view) again
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                // If this customer does not exist, create it
                _context.Customers.Add(customer);
            }
            else
            {
                // If this customer exists, get the customer from DB and edit it
                var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDB.Name = customer.Name;
                customerInDB.Birthdate = customer.Birthdate;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
                customerInDB.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }

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
