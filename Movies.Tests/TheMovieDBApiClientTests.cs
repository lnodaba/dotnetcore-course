using System;
using System.Collections.Generic;
using Trailers.MVC.Api;
using Trailers.MVC.DAL;
using Trailers.MVC.Models;
using Xunit;

namespace Movies.Tests
{
    public class TheMovieDBApiClientTests
    {
        [Fact]
        public void TestSearch()
        {
            //Arrange
            TheMovieDBApiClient client = new TheMovieDBApiClient();

            //Act
            var result = client.Search("Avengers");

            //Assert
            Assert.True(result.Count > 0);
        }

        [Fact]
        public void ItReturnsVideosForAGivenMovie()
        {
            //Arrange
            TheMovieDBApiClient client = new TheMovieDBApiClient();
            var movieId = 559;

            //Act
            var result = client.GetVideos(movieId);

            //Assert
            Assert.True(result.results.Length > 0);
        }

        [Fact]
        public void ItReurnsCreditsForAGivenMovie()
        {
            //Arrange
            TheMovieDBApiClient client = new TheMovieDBApiClient();
            var movieID = 559;
            //Act
            var result = client.GetCredits(movieID);

            //Assert
            Assert.True(result.cast.Length > 0);
        }



    }
}
