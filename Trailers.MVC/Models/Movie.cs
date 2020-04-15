using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trailers.MVC.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description{ get; set; }
        public string TrailerUrl{ get; set; }
        public string PosterUrl { get; set; }
        public int Year { get; set; }
        public int ApiID { get; set; }
        public bool IsFavorite { get; set; }



        public string All()
        {
           string all = this.ID.ToString() + 
                this.Title + 
                this.Description + 
                this.TrailerUrl + 
                this.Year.ToString();

            return all;
        }
    }
}
