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
            // If no movie in the DTO (customer did not rent any movie)
            if (newRentalDto.MovieIds.Count == 0)
                return BadRequest("New Movie Ids have been given.");
            
            // Get the customer and list of movies from DB
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == newRentalDto.CustomerId);
            
            if (customerInDB == null)
                return BadRequest("CustomerId is not valid.");

            var moviesInDB = _context.Movies.Where(m => newRentalDto.MovieIds.Contains(m.Id)).ToList();

            if (moviesInDB.Count != newRentalDto.MovieIds.Count)
                return BadRequest("One or more Movie Ids are invalid.");

            // For each movie rented, create a Rental object, add it to the Rental table.
            foreach (var movie in moviesInDB)
            {
                // Check if that movie is enough NumberAvailable for renting.
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                // Reduce the NumberAvailable for that movie
                movie.NumberAvailable--;

                // Create a Rental object
                var rental = new Rental()
                {
                    Customer = customerInDB,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                // Add Rental object to DB
                _context.Rentals.Add(rental);
            }

            return Ok();
        }
    }
}
