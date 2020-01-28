using System;
using System.Collections.Generic;
using Trailers.MVC.DAL;
using Trailers.MVC.Models;
using Xunit;

namespace Movies.Tests
{
    public class MoviesDALTests
    {
        [Fact]
        public void TestThatMoviesDALInsertsMovies()
        {
            //Arrange
            MoviesDAL dal = new MoviesDAL();

            Movie movie = new Movie();

            movie.Title = "Fast and Furious 100";
            movie.Description = "Not exists";
            movie.TrailerUrl = "asd";
            movie.PosterUrl = "asd";
            movie.Year = 2022;

            //Act
            dal.AddMovie(movie);

            //Assert

        }

        [Fact]
        public void TestThatMoviesDALReturnsMovies()
        {
            //Arrange
            MoviesDAL dal = new MoviesDAL();

            //Act
            List<Movie> movies = dal.ListMovies();

            //Assert
            Assert.True(movies.Count > 0);
        }
    }
}
