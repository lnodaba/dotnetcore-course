using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trailers.MVC.Models;

namespace Trailers.MVC.DAL
{
    public class MoviesDAL
    {
        private List<Movie> _movies = new List<Movie>()
        {
            new Movie()
            {
                ID = 1,
                Title = "Avenagers",
                Year = 1999,
                Description = "Very good movie",
                PosterUrl = "https://m.media-amazon.com/images/M/MV5BMTc5MDE2ODcwNV5BMl5BanBnXkFtZTgwMzI2NzQ2NzM@._V1_SY1000_CR0,0,674,1000_AL_.jpg",
                TrailerUrl = "https://www.youtube.com/watch?v=TcMBFSGVi1c"
            },
            new Movie()
            {
                ID = 2,
                Title = "Avenagers2",
                Year = 2001,
                Description = "Very very good movie",
                PosterUrl = "https://boygeniusreport.files.wordpress.com/2019/03/avengers-endgame-sign-2.jpg?quality=98&strip=all",
                TrailerUrl = "https://www.youtube.com/watch?v=TcMBFSGVi1c"
            },
            new Movie()
            {
                ID = 3,
                Title = "Avenagers3",
                Year = 2009,
                Description = "Very very very good movie",
                PosterUrl = "https://playtech.ro/wp-content/uploads/2019/04/avengers-endgame-recenzie-1170x658.jpg",
                TrailerUrl = "https://www.youtube.com/watch?v=TcMBFSGVi1c"
            }
        };

        public List<Movie> Search(string searchTerm)
        {
            List<Movie> result = new List<Movie>();

            foreach (Movie movie in _movies)
            {
                if(movie.All().Contains(searchTerm,StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(movie);
                }
            }
            return result;
        }

      

    }

}
