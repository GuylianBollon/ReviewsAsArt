using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAsArt.Models
{
    public class User : IdentityUser
    {
        public IList<Review> Reviews { get; set; }
        public IList<Bericht> Berichten { get; set; }
        public IList<User> Users { get; set; }
        public int Subscribers { get; set; }
    }
}
