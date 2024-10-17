using System.Net;
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
    public class MoviesController(VidlyContext context, IMapper mapper) : ControllerBase
    {
        private VidlyContext _context = context;
        private IMapper _mapper = mapper;

        // GET /api/movies
        [HttpGet]
        public IActionResult GetMovies()
        {
            var movies = _context.Movies.ToList();
            var movieDtos = _mapper.Map<List<MovieDto>>(movies);
            return Ok(movieDtos);
        }

        // GET /api/movies/{id}
        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();
            
            var movieDto = _mapper.Map<MovieDto>(movie);
            return Ok(movieDto);
        }

        // POST /api/movies
        [HttpPost]
        public IActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Map MovieDto to Movie entity
            var movie = _mapper.Map<Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            // Map the created Movie back to the MovieDto to return
            var createdMovieDto = _mapper.Map<MovieDto>(movie);

            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, createdMovieDto);
        }

        // PUT /api/movies/1
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                return NotFound();

            // Map miveDto to movieInDb and save to DB
            _mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/movies/1
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
