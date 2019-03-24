using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAsArt.Models
{
    public class Review
    {
        public string Titel { get; set; }
        public string Beschrijving { get; set; }
        private int? _score;
        public Reviewgenre Rg { get; set; }
        public int? Score { get { return _score; } set { if (Score < 0) { throw new ArgumentException("Score moet boven de 0 blijven."); } if (Score > Rg.Score) { throw new ArgumentException("Score moet onder of gelijk aan het maximum zijn"); } _score = Score; } }
        public int ReviewScore { get; set; }
        public IEnumerable<Commentaar> Commentaars { get; set; } 
        public Werk Werk { get; set; }
    }
}
