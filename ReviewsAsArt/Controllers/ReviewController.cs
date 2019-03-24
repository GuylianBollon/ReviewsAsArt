using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewsAsArt.Models;

namespace ReviewsAsArt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    internal class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _irr;

        public ReviewController(IReviewRepository irr)
        {
            _irr = irr;
        }
        
        [HttpGet]
        public IEnumerable<Review> GetReviews()
        {
            return _irr.GetReviews();
        }

        [HttpGet("{rg}")]
        public IEnumerable<Review> GetReviewsPerReviewgenre(Reviewgenre rg)
        {
            return _irr.GetReviewsPerReviewgenre(rg);
        }

        [HttpGet("{werk,rg}")]
        public IEnumerable<Review> GetReviewsPerWerkEnReviewgenre(Werk werk, Reviewgenre rg)
        {
            return _irr.GetReviewsPerWerkenReviewgenre(werk, rg);
        }

        [HttpGet("{review}")]
        public IEnumerable<Commentaar> GetCommentaars(Review review)
        {
            return _irr.GetCommentaarsVanReview(review);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("{review}")]
        public void PlusAanReview(Review review)
        {
            _irr.AddScore(review);
            _irr.SaveChanges();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("{review}")]
        public void MinAanReview(Review review)
        {
            _irr.RemoveScore(review);
            _irr.SaveChanges();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("{review}")]
        public void RemoveReview(Review review)
        {
            _irr.RemoveReview(review);
            _irr.SaveChanges();
        }
    }
}