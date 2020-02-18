using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trailers.MVC.Models
{
    public class ApiCreditsResult
    {
        public int id { get; set; }
        public Cast[] cast { get; set; }
        public Crew[] crew { get; set; }
    }

    public class Cast
    {
        public int cast_id { get; set; }
        public string character { get; set; }
        public string credit_id { get; set; }
        public int gender { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int order { get; set; }
        public string profile_path { get; set; }
    }

    public class Crew
    {
        public string credit_id { get; set; }
        public string department { get; set; }
        public int gender { get; set; }
        public int id { get; set; }
        public string job { get; set; }
        public string name { get; set; }
        public string profile_path { get; set; }
    }

}
