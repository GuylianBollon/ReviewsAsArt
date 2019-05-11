using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAsArt.Models
{
    public interface IUserRepository
    {
        IEnumerable<Review> ToonReviewsVanUser(User user);
        IEnumerable<Review> ToonReviewsVanSubscripties(IEnumerable<User> users);
        IEnumerable<User> GetUsers();
        void SaveChanges();
        void Add(User user);
        User GetBy(string name);
    }
}
