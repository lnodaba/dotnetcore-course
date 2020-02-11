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

    }
}
