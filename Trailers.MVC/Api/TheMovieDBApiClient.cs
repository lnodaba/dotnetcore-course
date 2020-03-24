using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Trailers.MVC.Models;

namespace Trailers.MVC.Api
{
    public class TheMovieDBApiClient
    {
        private string _apiEndpoint = "https://api.themoviedb.org/3";
        private string _apiKey = "2bdd3c7cd3b1a0d237f5986e5418e4eb";
        private string _defaultParameters = "&language=en-US&page=1&include_adult=false";

        private HttpClient _client = new HttpClient();


        public bool MarkAsFavorite(int MovieApiId)
        {
            string queryUrl = _apiEndpoint + "/account/3/favorite" +
                       "?api_key=b3ec4a9ec89b8292324a5bcb560d0713" +
                       "&session_id=b5492e15be1a68284a35e5844f3e06bd6a098f35";
            
            var body = $"{{ \"media_type\" : \"movie\", \"media_id\": {MovieApiId}, \"favorite\": true }}";

            var response = _client.PostAsync(queryUrl, new StringContent(body, Encoding.UTF8, "application/json"))
                .GetAwaiter().GetResult();
            
            string jsonString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            return false;
        }

        public List<Movie> Search(string query)
        {
            string queryUrl = getSearchQuery(query);

            string jsonString = runGetRequest(queryUrl);

            return searchResultToMovies(jsonString);
        }
        public ApiVideosResult GetVideos(int apiID)
        {
            string queryUrl = getVideoQuery(apiID);

            string jsonString = runGetRequest(queryUrl);

            return JsonSerializer.Deserialize<ApiVideosResult>(jsonString);
        }
        public ApiCreditsResult GetCredits(int apiID)
        {
            string queryUrl = getCreditQuery(apiID);

            string jsonString = runGetRequest(queryUrl);

            return JsonSerializer.Deserialize<ApiCreditsResult>(jsonString);
        }

        private static List<Movie> searchResultToMovies(string jsonString)
        {
            var result = new List<Movie>();

            SearchResult searchResult = JsonSerializer.Deserialize<SearchResult>(jsonString);
            foreach (var movieItem in searchResult.results.ToList())
            {
                var date = DateTime.Now;
                
                if (movieItem.release_date?.Length > 0)
                {
                    date = DateTime.Parse(movieItem.release_date);
                }

                result.Add(new Movie()
                {
                    Title = movieItem.title,
                    Description = movieItem.overview,
                    PosterUrl = movieItem.poster_path,
                    Year = date.Year,
                    ApiID = movieItem.id
                });
            }

            return result;
        }

        private static List<Movie> searchResultToMovies(string jsonString,bool elegant) => 
            JsonSerializer.Deserialize<SearchResult>(jsonString)
                .results
                .ToList()
                .Select(x => new Movie()
                {
                    Title = x.title,
                    Description = x.overview,
                    PosterUrl = x.poster_path,
                    Year = x.release_date.Length > 0 
                            ? DateTime.Parse(x.release_date).Year : DateTime.Now.Year
                }).ToList();

        internal List<Movie> SearchWithActor(string searchTerm)
        {
            throw new NotImplementedException();
        }

        private string runGetRequest(string queryUrl)
        {
            HttpResponseMessage httpResult = _client.GetAsync(queryUrl).GetAwaiter().GetResult();
            string jsonString = httpResult.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return jsonString;
        }

        private string getSearchQuery(string query) => _apiEndpoint + "/search/movie" +
                        $"?api_key={_apiKey}" +
                        $"&query={query}" +
                       _defaultParameters;

        private string getVideoQuery(int apiID) => _apiEndpoint + $"/movie/{apiID}/videos" +
                $"?api_key={_apiKey}";
        private string getCreditQuery(int apiID) => _apiEndpoint + $"/movie/{apiID}/credits" +
                $"?api_key={_apiKey}";
    }
}
