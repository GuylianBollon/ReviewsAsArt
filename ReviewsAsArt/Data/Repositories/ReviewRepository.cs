using Microsoft.EntityFrameworkCore;
using ReviewsAsArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAsArt.Data.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DbSet<Review> _dr;
        private readonly ApplicationDbContext _adc;
        public ReviewRepository(ApplicationDbContext adc)
        {
            _dr = adc.Reviews;
            _adc = adc;
        }

        public List<Commentaar> GetCommentaarsVanReview(Review review)
        {
            return _dr.FirstOrDefault(r => r == review).Commentaars.ToList();
        }

        public IEnumerable<Review> GetReviews()
        {
            return _dr.ToList();
        }

        public List<Review> GetReviewsPerReviewgenre(Reviewgenre reviewgenre)
        {
            return _dr.Where(r => r.Rg == reviewgenre).ToList();
        }

        public List<Review> GetReviewsPerWerkenReviewgenre(Werk werk, Reviewgenre rg)
        {
            return _dr.Where(r => r.Rg == rg && r.Werk == werk).ToList();
        }

        public void RemoveReview(Review review)
        {
            _dr.Remove(review);
        }

        public void SaveChanges()
        {
            _adc.SaveChanges();
        }
    }
}
