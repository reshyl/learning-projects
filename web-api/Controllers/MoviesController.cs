using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesService moviesService;

        public MoviesController(MoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        [HttpGet]
        public async Task<List<Movie>> Get()
        {
            return await moviesService.GetAllMoviesAsync();
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Movie>> Get(string id)
        {
            var movie = await moviesService.GetMovieByIdAsync(id);

            if (movie == null)
                return NotFound();

            return movie;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Movie movie)
        {
            if (movie == null)
                return BadRequest("Movie cannot be null.");

            await moviesService.CreateMovieAsync(movie);
            return CreatedAtAction(nameof(Get), new { id = movie.Id }, movie);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Movie updatedMovie)
        {
            if (updatedMovie == null || updatedMovie.Id != id)
                return BadRequest("Movie ID mismatch.");

            var existingMovie = await moviesService.GetMovieByIdAsync(id);

            if (existingMovie == null)
                return NotFound();

            updatedMovie.Id = existingMovie.Id;
            await moviesService.UpdateMovieAsync(id, updatedMovie);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existingMovie = await moviesService.GetMovieByIdAsync(id);

            if (existingMovie == null)
                return NotFound();

            await moviesService.DeleteMovieAsync(id);
            return NoContent();
        }
    }
}
