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

        public IActionResult ListMovies()
        {
            MoviesDAL dal = new MoviesDAL();

            List<Movie> result = dal.Search("Avenger");
            
            return View(result);
        }
    }
}