using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAsArt.Models
{
    internal interface IReviewRepository
    {
        void AddScore(Review review);
        void RemoveScore(Review review);
        void SaveChanges();
        List<Review> GetReviewsPerReviewgenre(Reviewgenre reviewgenre);
        List<Commentaar> GetCommentaarsVanReview(Review review);
        List<Review> GetReviewsPerWerkenReviewgenre(Werk werk, Reviewgenre rg);
        IEnumerable<Review> GetReviews();
        void RemoveReview(Review review);
    }
}
