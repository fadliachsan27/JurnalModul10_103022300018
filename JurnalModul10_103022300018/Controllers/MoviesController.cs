using Microsoft.AspNetCore.Mvc;
using JurnalModul10_103022300018.Models;
using System.Collections.Generic;

namespace JurnalModul10_103022300018.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private static List<Movies> daftarMovie = new List<Movies>
        {
            new Movies("The Shawshank Redemption", "Frank Darabont", new List<string> { "Tim Robbins", "Morgan Freeman", "Bob Gunton" }, 
                "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion."),
            new Movies("The Godfather", "Francis Ford Coppola", new List<string> { "Marlon Brando", "Al Pacino", "James Caan" }, 
                "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."),
            new Movies("The Dark Knight", "Christopher Nolan", new List<string> { "Christian Bale", "Heath Ledger", "Aaron Eckhart" }, 
                "When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness."),
        };

        [HttpGet]
        public ActionResult<List<Movies>> GetMovie()
        {
            return daftarMovie;
        }

        [HttpGet("{index}")]
        public ActionResult<Movies> GetMovieByIndex(int index)
        {
            if (index < 0 || index >= daftarMovie.Count)
            {
                return NotFound();
            }
            return daftarMovie[index];
        }

        [HttpPost]
        public ActionResult<Movies> AddMovie([FromBody] Movies movie)
        {
            if (movie == null)
            {
                return BadRequest();
            }
            daftarMovie.Add(movie);
            return CreatedAtAction(nameof(GetMovieByIndex), new { index = daftarMovie.Count - 1 }, movie);
        }

        [HttpDelete("{index}")]
        public ActionResult DeleteMovie(int index)
        {
            if (index < 0 || index >= daftarMovie.Count)
            {
                return NotFound();
            }
            daftarMovie.RemoveAt(index);
            return NoContent();
        }
    }
}
