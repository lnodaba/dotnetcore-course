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