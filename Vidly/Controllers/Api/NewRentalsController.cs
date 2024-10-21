using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vidly.Data;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewRentalsController(VidlyContext context, IMapper mapper) : ControllerBase
    {
        private VidlyContext _context = context;
        private IMapper _mapper = mapper;

        // POST /api/newrentals
        [HttpPost]
        public IActionResult CreateNewRentals(NewRentalDto newRentalDto)
        {
            // Get the customer and list of movies from DB
            var customerInDB = _context.Customers.Single(c => c.Id == newRentalDto.CustomerId);
            var moviesInDB = _context.Movies.Where(m => newRentalDto.MovieIds.Contains(m.Id));

            // For each movie rented, create a Rental object, add it to the Rental table.
            foreach (var movie in moviesInDB)
            {
                var rental = new Rental()
                {
                    Customer = customerInDB,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            return Ok();
        }
    }
}
