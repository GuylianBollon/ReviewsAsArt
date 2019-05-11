using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAsArt.Models
{
    public class Reviewgenre
    {
        public String Titel { get; set; }
        public IList<string> Regels { get; set; }
        private int? _score;
        public int? Score { get { return _score; } set { if (value <= 0) { throw new ArgumentException("Score moet boven de 0 zijn."); } _score = value; } }
        public IList<string> GeblokkeerdeUserIDs { get; set; }
        public Admin Admin { get; set; }
    }
}
