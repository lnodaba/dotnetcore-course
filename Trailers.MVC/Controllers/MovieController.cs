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
            ////TODO:
            ///Step 1 - MoviesDAL peldany
            ///Step 2 - Meghivjuk a movies add fugvenyt.
            ///Step 3 - Letrezhozni a MoviesAdd DAL fugvenyt
            Movie myMovie = movie;

            return RedirectToAction("Index"); //this needs to redirect to the listing page
        }

        public IActionResult ListMovies()
        {
            MoviesDAL dal = new MoviesDAL();

            List<Movie> result = dal.Search("Avenger");
            
            return View(result);
        }
    }
}