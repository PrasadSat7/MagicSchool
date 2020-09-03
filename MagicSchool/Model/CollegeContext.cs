using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MagicSchool.Model
{
    public class CollegeContext: DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DbSet<MovieDetails> MovieDetails { get; set; }


        public CollegeContext(DbContextOptions<CollegeContext> options)
            :base(options)
           
        {
            //MovieItems.Add(new Movie { MovieId = 1 , MovieName = "CID" , MovieLanguage = "Hindi"});
            //movies.Add(new Movie { MovieId = 1, MovieName = "CID", MovieLanguage = "Hindi" });
            //movies.Add(new Movie { MovieId = 2, MovieName = "RockOn", MovieLanguage = "Hindi" });
            //movies.Add(new Movie { MovieId = 3, MovieName = "Powero", MovieLanguage = "Kannada" });

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=DESKTOP-DV8BFFP\\SQLEXPRESS;Database=SchoolDetails;Trusted_Connection=True;");
        //    }
        //}


        //private List<Movie> movies = new List<Movie>();

        public List<Movie> GetMovies() 
        {
            return Movies.ToList();
        }

        public Movie GetMovie(int id)
        {
            return Movies.FirstOrDefault(a => a.MovieId == id);
        }

        public List<Movie> InsertMovie(Movie movie)
        {
            Movies.Add(movie);            
            return Movies.ToList();
        }
    }
}
