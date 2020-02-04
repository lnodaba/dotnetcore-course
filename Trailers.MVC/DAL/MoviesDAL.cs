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
                $"INSERT INTO [dbo].[Movies] ([Title],[Year],[Description],[PosterUrl],[TrailerUrl])" +
                $"VALUES ('{movie.Title}', '{movie.Year}', '{movie.Description}','{movie.PosterUrl}','{movie.TrailerUrl}')";

            int result = runQuery(commandText);

            return result == 1
                ? true : false;
        }

        private int runQuery(string commandText)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand(commandText, connection as SqlConnection);

            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();

            return result;

        }

        public bool UpdateMovie(Movie movie)
        {
            string commandText = 
                   $" UPDATE[dbo].[Movies] " +
                   $" SET[Title] = '{movie.Title}' " +
                   $"     ,[Year] = {movie.Year} " +
                   $"     ,[Description] ='{movie.Description}' " +
                   $"     ,[PosterUrl] = '{movie.PosterUrl}' " +
                   $"     ,[TrailerUrl] = '{movie.TrailerUrl}' " +
                   $" WHERE ID = {movie.ID}";

            int result = runQuery(commandText);

            return result == 1
                ? true : false;
        }

        public List<Movie> ListMovies(string searchParameter = "")
        {
            string commandText = "SELECT [ID], [Title], [Year], [Description], [PosterUrl], [TrailerUrl] FROM[dbo].[Movies]";
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
                    };
                    movies.Add(movie);
                }
            }
            return movies;
        }
        public Movie GetMovie(int id) => 
            this.ListMovies(searchParameter : $" WHERE ID = {id}")
            .First();

    }

}
