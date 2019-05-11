using ReviewsAsArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAsArt.DTO
{
    public class AdminDTO
    {
        public User user { get; set; }
        public Reviewgenre rg { get; set; }
    }
}
