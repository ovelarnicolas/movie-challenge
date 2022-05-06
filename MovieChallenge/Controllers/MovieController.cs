using Microsoft.AspNetCore.Mvc;
using MovieChallenge.Models;
using MovieChallenge.Services;

namespace MovieChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService) => _movieService = movieService;

        [HttpGet]
        public async Task<List<Movie>> Get() => await _movieService.GetAllAsync();


        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> Get(string id)
        {
            var movie = await _movieService.GetAsync(id);

            if (movie == null) return NotFound();

            return movie;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Movie newMovie)
        {
            await _movieService.CreateAsync(newMovie);

            return CreatedAtAction(nameof(Get), new { id = newMovie.Id }, newMovie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Movie updatedMovie)
        {
            var Movie = await _movieService.GetAsync(id);

            if (Movie is null) return NotFound();

            updatedMovie.Id = Movie.Id;

            await _movieService.UpdateAsync(id, updatedMovie);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var Movie = await _movieService.GetAsync(id);

            if (Movie is null) return NotFound();

            await _movieService.DeleteAsync(id);

            return NoContent();
        }
    }
}
