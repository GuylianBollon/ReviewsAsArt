using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAsArt.Models
{
    public interface IReviewGenreRepository
    {
        void AddReviewGenre(Reviewgenre rg);
        void SaveChanges();
        bool IsGeblokkeerd(User user, Reviewgenre rg);
        void BlokkeerUser(User user, Reviewgenre rg);
        void DeblokkeerUser(User user, Reviewgenre rg);
        IEnumerable<Reviewgenre> GetReviewgenres();
        bool IsAdmin(User user, Reviewgenre rg);
        string GetAdminNaam(Reviewgenre rg);
    }
}
