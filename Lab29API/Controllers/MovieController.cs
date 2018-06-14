using Lab29API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lab29API.Controllers
{
    public class MovieController : ApiController
    {
        [HttpGet]
        public List<Movie> ShowAllMovies()
        {
            MovieDBEntities ORM = new MovieDBEntities();

            return ORM.Movies.ToList();
            //http://localhost:55657/api/Movie/ShowAllMovies
        }

        [HttpGet]
        public List<Movie> ShowMovieCategory(string category)
        {
            MovieDBEntities ORM = new MovieDBEntities();

            return ORM.Movies.Where(c => c.Category.Contains(category)).ToList();
            //http://localhost:55657/api/Movie/ShowMovieCategory?category=Horror
        }

        [HttpGet]
        public Movie ShowRandomMovie()
        {
            // public Movie due to only asking for one random movie to be returned
            MovieDBEntities ORM = new MovieDBEntities();

            Random r = new Random();

            List<Movie> Movies = ORM.Movies.ToList();

            return Movies[r.Next(0, Movies.Count)];
        }

        [HttpGet]
        public Movie GetRandomMovieByCategory(string category)
        {
            MovieDBEntities ORM = new MovieDBEntities();

            Random r = new Random();

            List<Movie> Movies = ORM.Movies.Where(c => c.Category.Contains(category)).ToList();

            return Movies[r.Next(0, Movies.Count)];
        }

        [HttpGet]
        public List<Movie> ShowRandomMovieList(int amount)
        {
            // public Movie due to only asking for one random movie to be returned
            MovieDBEntities ORM = new MovieDBEntities();


            Random r = new Random();

            List<Movie> Movies = ORM.Movies.ToList();
            List<Movie> Moovies = new List<Movie>();

            for (int i = 0; i < amount; i++)
            {
                int result = r.Next(Movies.Count());
                Movies.Add(Moovies[result]);
                Moovies.RemoveAt(result);

            }
            return Movies;
            
        }


        [HttpGet]
        public List<string> CategoryList()
        {
            MovieDBEntities ORM = new MovieDBEntities();

            return ORM.Movies.Select(c => c.Category).Distinct().ToList();

        }
    }
}
