using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicSchool.Model;
using Microsoft.AspNetCore.Mvc;

namespace MagicSchool.Controllers
{

    [ApiController]
    [Route("api/[controller]")]    
   public class CollegeController : Controller
    {

    private readonly CollegeContext _context;
        public List<Movie> Movies = new List<Movie>();
        public Movie HM;

    public CollegeController(CollegeContext context)
    {
        _context = context;
    }

        [HttpGet("Movies")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            //HM.MovieId = 1;
            //HM.MovieLanguage = "CID";
            //HM.MovieLanguage = "Hindi";
            //Movies.Add(new Movie { MovieId = 1, MovieName = "CID", MovieLanguage = "Hindi" });
            // return _context.MovieItems.ToList();
            //Movies.Add(HM);
            //return _context.GetMovies().ToList();
            return _context.Movies.ToList();
        }

        [HttpGet("GetMovie/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Movie>> GetMovieItem(int id)
        {
            //return _context.GetMovies().ToList().First(a => a.MovieId == id);
            return _context.GetMovie(id);
        }

        [HttpGet("GetMovieByid")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Movie>> GetMovieItemById([FromBody]GetItemrequest request)
        {
            //return _context.GetMovies().ToList().First(a => a.MovieId == request.id);
            return _context.GetMovie(request.id);
        }

        [HttpPost("InsertMovie")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Movie>>> InsertMovie([FromBody]Movie request)
        {
            //return _context.InsertMovie(request);
            _context.Movies.Add(request);
            _context.SaveChanges();
            return _context.Movies.ToList();

        }
        
        [HttpDelete("DeleteMovie")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<long> DeleteMovie([FromBody]GetItemrequest request)
        {
            int MoviID = 0;
            var  Remov =  _context.Movies.FirstOrDefault( a => a.MovieId == request.id);
            _context.Remove(Remov);
            MoviID = _context.SaveChanges();
            return MoviID;
        }

        [HttpPut("UpdateMovie")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<Movie> UpdateMovie([FromBody]Movie request)
        {
           
            Movie UpdateItem;
            UpdateItem = _context.Movies.FirstOrDefault(a => a.MovieId == request.MovieId);
            UpdateItem.MovieLanguage = request.MovieLanguage;
            UpdateItem.MovieName = request.MovieName;
            _context.SaveChanges();
            //_context.Movies.Where(a => a.MovieId == request.MovieId);  ORM
            return _context.Movies.FirstOrDefault(a => a.MovieId == request.MovieId); ;
        }

        [HttpGet("GetMovieDetails")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<MovieDetails> GetMovieDetails([FromBody]GetItemrequest request)
        {

            MovieDetails movieDetails;
            movieDetails = (from md in _context.MovieDetails
                          join m in _context.Movies on md.Movie_ID equals m.MovieId
                          where md.Movie_ID == request.id
                          orderby m.MovieId
                          select md).FirstOrDefault();


            //_context.Movies.Where(a => a.MovieId == request.MovieId);  ORM
            return movieDetails;
        }
    }
}