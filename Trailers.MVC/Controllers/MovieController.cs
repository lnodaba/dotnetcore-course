using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trailers.MVC.Api;
using Trailers.MVC.DAL;
using Trailers.MVC.Models;

namespace Trailers.MVC.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            MoviesDAL dal = new MoviesDAL();

            dal.AddMovie(movie);

            return RedirectToAction("Index"); //this needs to redirect to the listing page
        }

        public IActionResult Details(int id)
        {
            MoviesDAL dal = new MoviesDAL();

            Movie movie = dal.GetMovie(id);

            return View(dal.GetMovie(id));

            //TODO:
            // There are 2 endpoints to implement
            // For credits: https://api.themoviedb.org/3/movie/112679/credits?api_key=2bdd3c7cd3b1a0d237f5986e5418e4eb
            // For Videos: https://api.themoviedb.org/3/movie/1930/videos?api_key=2bdd3c7cd3b1a0d237f5986e5418e4eb&language=en-US
            // Implement 2 public methods on the MovieDBApi client.
            /*
             * Create the classes needed with this technique:
             * https://www.c-sharpcorner.com/article/how-to-paste-json-as-classes-or-xml-as-classes-in-visual-stu/
             * 
             * Create a new Class name it MovieDetail Model
             * and add the movie itself the credits and the videos it
             *  
             *  Create an instance here in the details action and return that to the view.
             *  
             *  Chage the movie details view's Model to MovieDetailsViewModel
             *  and thn change the UI.
             */
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            MoviesDAL dal = new MoviesDAL();

            Movie movie = dal.GetMovie(id);

            return View(dal.GetMovie(id));
        }

        [HttpPost]
        public IActionResult Update(Movie movie)
        {
            MoviesDAL dal = new MoviesDAL();

            dal.UpdateMovie(movie);
            
            return RedirectToAction("Index"); //this needs to redirect to the listing page
        }




        public IActionResult ListMovies()
        {
            MoviesDAL dal = new MoviesDAL();

            List<Movie> result = dal.ListMovies();
            
            return View(result);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            MoviesDAL dal = new MoviesDAL();

            Movie movie = dal.GetMovie(id);

            return View(dal.GetMovie(id));
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            MoviesDAL dal = new MoviesDAL();

            dal.DeleteMovie(movie);

            return RedirectToAction("ListMovies");
        }
        public IActionResult Import()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Import(string searchTerm)
        {
            TheMovieDBApiClient api = new TheMovieDBApiClient();
            List<Movie> movies = api.Search(searchTerm);

            MoviesDAL dal = new MoviesDAL();
            foreach (Movie movie in movies)
            {
                dal.AddMovie(movie);
            }

            return RedirectToAction("ListMovies");
        }
    }

}