using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewsAsArt.DTO;
using ReviewsAsArt.Models;

namespace ReviewsAsArt.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _irr;

        public ReviewController(IReviewRepository irr)
        {
            _irr = irr;
        }
        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<Review> GetReviews()
        {
            return _irr.GetReviews();
        }
        [AllowAnonymous]
        [HttpGet("{rg}")]
        public IEnumerable<Review> GetReviewsPerReviewgenre(Reviewgenre rg)
        {
            return _irr.GetReviewsPerReviewgenre(rg);
        }
        [AllowAnonymous]
        [HttpGet("{filter}")]
        public IEnumerable<Review> GetReviewsPerWerkEnReviewgenre(SorteerDTO sd)
        {
            return _irr.GetReviewsPerWerkenReviewgenre(sd.werk,sd.rg);
        }
        [AllowAnonymous]
        [HttpGet("{review}")]
        public IEnumerable<Commentaar> GetCommentaars(Review review)
        {
            return _irr.GetCommentaarsVanReview(review);
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