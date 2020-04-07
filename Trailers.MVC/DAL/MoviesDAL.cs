using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Trailers.MVC.Models;

namespace Trailers.MVC.DAL
{ 
    public class MoviesDAL
    {
        private string _connectionString = "Server=NODA;Database=AwesomeProject;User Id=AwesomeUser;Password=123qwe;";

        public bool AddMovie(Movie  movie)
        {
            string commandText =
                $"INSERT INTO [dbo].[Movies] ([Title],[Year],[Description],[PosterUrl],[TrailerUrl], [ApiID])" +
                $"VALUES (@Title, @Year, @Description, @PosterUrl, @TrailerUrl, @ApiID)";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("Title",movie.Title),
                new SqlParameter("Year",movie.Year),
                new SqlParameter("Description",movie.Description),
                new SqlParameter("PosterUrl",movie.PosterUrl ?? string.Empty),
                new SqlParameter("TrailerUrl",movie.TrailerUrl ?? string.Empty) ,
                new SqlParameter("ApiID",movie.ApiID)
            };

            int result = runQuery(commandText, parameters);

            return result == 1
                ? true : false;
        }
        public bool UpdateMovie(Movie movie)
        {
            string commandText = 
                   $" UPDATE[dbo].[Movies] " +
                   $" SET [Title] = @Title " +
                   $"     ,[Year] = @Year " +
                   $"     ,[Description] = @Description " +
                   $"     ,[PosterUrl] = @PosterUrl  " +
                   $"     ,[TrailerUrl] = @TrailerUrl " +
                   $" WHERE ID = @ID ";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("Title",movie.Title),
                new SqlParameter("Year",movie.Year),
                new SqlParameter("Description",movie.Description),
                new SqlParameter("PosterUrl",movie.PosterUrl ?? string.Empty),
                new SqlParameter("TrailerUrl",movie.TrailerUrl ?? string.Empty),
                new SqlParameter("ID",movie.ID)
            };

            int result = runQuery(commandText, parameters);

            return result == 1
                ? true : false;
        }

        public void ToggleFavorite(int movieId, string email)
        {
            string commandText = " IF(EXISTS(SELECT * FROM Favorites WHERE Email = @email AND MovieId = @movieId)) " +
                                " BEGIN                                                                           " +
                                "     DELETE FROM[dbo].[Favorites] WHERE Email = @email AND MovieId = @movieId    " +
                                " END                                                                             " +
                                " ELSE                                                                            " +
                                " BEGIN                                                                           " +
                                "     INSERT INTO[dbo].[Favorites]([MovieId],[Email]) VALUES(@movieId, @email)    " +
                                " END                                                                             ";


            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("MovieId",movieId),
                new SqlParameter("Email",email),
            };

            runQuery(commandText, parameters);
        }

        public List<Movie> ListMovies(string searchParameter = "")
        {
            string commandText = "SELECT [ID], [Title], [Year], [Description], [PosterUrl], [TrailerUrl], [ApiID] FROM[dbo].[Movies]";
            commandText += searchParameter;

            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand(commandText, connection as SqlConnection);
            
            List<Movie> movies = new List<Movie>();

            using (var adapter = new SqlDataAdapter(command))
            {
                var resultTable = new DataTable();
                adapter.Fill(resultTable);

                foreach (var row in resultTable.AsEnumerable())
                {
                    Movie movie = new Movie()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Title = row["Title"].ToString(),
                        Year = int.Parse(row["Year"].ToString()),
                        Description = row["Description"].ToString(),
                        PosterUrl = row["PosterUrl"].ToString(),
                        TrailerUrl = row["TrailerUrl"].ToString(),
                        ApiID = int.Parse(row["ApiID"].ToString())
                    };
                    movies.Add(movie);
                }
            }
            return movies;
        }

        internal Movie GetMovieByApiId(int apiID)
        {
            throw new NotImplementedException();
        }

        public Movie GetMovie(int id) => 
            this.ListMovies(searchParameter : $" WHERE ID = {id}")
            .First();

        private int runQuery(string commandText)
        {
            return runQuery(commandText, new List<SqlParameter>());
        }

        private int runQuery(string commandText, List<SqlParameter> parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand(commandText, connection as SqlConnection);
            
            parameters.ForEach(parameter => command.Parameters.Add(parameter));
            
            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();

            return result;

        }

        public bool DeleteMovie(Movie movie)
        {
            return DeleteMovieById(movie.ID);
        }

        public bool DeleteMovieById(int id)
        {
            string commandText =
                               $" DELETE FROM [dbo].[Movies] WHERE ID = {id}";

            int result = runQuery(commandText);

            return result == 1
                ? true : false;
        }
    }

}
