﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Trailers.MVC.Api;
using Trailers.MVC.DAL;
using Trailers.MVC.Models;

namespace Trailers.MVC.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        private MoviesDAL _dal;
        private TheMovieDBApiClient _api;

        public MovieController(IConfiguration configuration)
        {
            _dal = new MoviesDAL(configuration.GetConnectionString("UsersContextConnection"));
            _api = new TheMovieDBApiClient();
        }

        public IActionResult Index() => View();

        public IActionResult ListMovies()
        {
            var email = HttpContext.User.Identity.Name;
            var movies = _dal.ListMovies("",email);
            
            //var favorites = _dal.GetFavorites(email);

            //foreach (var movieId in favorites)
            //{
            //    for (int i = 0; i < movies.Count; i++)
            //    {
            //        if (movies[i].ID == movieId)
            //        {
            //            movies[i].IsFavorite = true;
            //        }
            //    }
            //}

            return View(movies);
        } 

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            _dal.AddMovie(movie);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Movie movie = _dal.GetMovie(id);

            return View(new MovieDetailsViewModel()
            {
                movie = movie,
                credits = _api.GetCredits(movie.ApiID),
                videos = _api.GetVideos(movie.ApiID)
            });
        }

        [HttpGet]
        public IActionResult Update(int id) => View(_dal.GetMovie(id));

        [HttpPost]
        public IActionResult Update(Movie movie)
        {
            _dal.UpdateMovie(movie);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id) => View(_dal.GetMovie(id));

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _dal.DeleteMovie(movie);

            return RedirectToAction("ListMovies");
        }

        [HttpPost]
        public IActionResult DeleteMovie(int id)
        {
            try
            {
                _dal.DeleteMovieById(id);

                return Ok(1);
            }
            catch (Exception)
            {
                return Ok(0);
            }
           
        }

        [HttpPost]
        public IActionResult Favorite(int id)
        {
            try
            {
                var email = HttpContext.User.Identity.Name;
                _dal.ToggleFavorite(id,email);

                return Ok(1);
            }
            catch (Exception)
            {
                return Ok(0);
            }

        }

        [HttpGet]
        public List<int> GetFavorites()
        {
            var email = HttpContext.User.Identity.Name;
            return _dal.GetFavorites(email);
        }

        public IActionResult Import() => View();

        [HttpPost]
        public IActionResult Import(string searchTerm)
        {
            List<Movie> movies = _api.Search(searchTerm);
            foreach (Movie movie in movies)
            {
                _dal.AddMovie(movie);
            }

            return RedirectToAction("ListMovies");
        }

        public IActionResult Search() => View(new List<Movie>());

        [HttpPost]
        public IActionResult Search(string searchTerm)
        {
            List<Movie> movies = _api.Search(searchTerm);

            return View(movies);
        }

        [HttpPost]
        public IActionResult SearchWithActor(string searchTerm)
        {
            if (searchTerm == null)
            {
                return View(new List<Movie>());
            }

            List<Movie> apiMovies = _api.SearchWithActor(searchTerm);
            for (int i = 0; i < apiMovies.Count; i++)
            {
                var exists = movieExists(apiMovies[i]);
                if (!exists)
                {
                    _dal.AddMovie(apiMovies[i]);
                }

                apiMovies[i] = _dal.GetMovieByApiId(apiMovies[i].ApiID);
            }

            return View(apiMovies);
        }

        private bool movieExists(Movie currentMovie)
        {
            var result = _dal.GetMovieByApiId(currentMovie.ApiID);
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public IActionResult Graphs()
        {
            var dataPoints = _dal.GetDataPoints();

            return View(dataPoints);
        }

    }

}