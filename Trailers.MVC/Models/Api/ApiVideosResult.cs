using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trailers.MVC.Models
{

    public class ApiVideosResult
    {
        public int id { get; set; }
        public Result[] results { get; set; }
    }

    public class Result
    {
        public string id { get; set; }
        public string iso_639_1 { get; set; }
        public string iso_3166_1 { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public string site { get; set; }
        public int size { get; set; }
        public string type { get; set; }
    }

}
