using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult ListMovies()
        {
            MoviesDAL dal = new MoviesDAL();

            List<Movie> result = dal.ListMovies();
            
            return View(result);
        }
    }
}