using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Codetest2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MoviesContext())
            {
                // Create a new movie
                var movie = new Movie { Moviename = "The Matrix", DateofRelease = new DateTime(1999, 3, 31) };
                db.Movies.Add(movie);
                db.SaveChanges();

                // Display movies released in 1999
                var movies1999 = db.Movies.Where(m => m.DateofRelease.Year == 1999);
                Console.WriteLine("Movies released in 1999:");
                foreach (var m in movies1999)
                {
                    Console.WriteLine("- " + m.Moviename);
                }

                // Update the movie
                movie.Moviename = "The Matrix Reloaded";
                db.SaveChanges();

                // Delete the movie
                db.Movies.Remove(movie);
                db.SaveChanges();
            }
        }
    }

    public class Movie
    {
        public int Mid { get; set; }
        public string Moviename { get; set; }
        public DateTime DateofRelease { get; set; }
    }

    public class MoviesContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}
