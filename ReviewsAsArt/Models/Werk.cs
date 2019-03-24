using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAsArt.Models
{
    public class Werk
    {
        public String Titel { get; set; }
        public int Creatiejaar { get; set; }
        public enum Medium { Boek, Film, Televisieserie, Album, Bordspel, Videospel, Theateruitvoering }
        public Medium Media { get; set; }
    }
}
