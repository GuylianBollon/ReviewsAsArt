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
    internal class ReviewGenreController : ControllerBase
    {
        private readonly IReviewGenreRepository _irgr;

        public ReviewGenreController(IReviewGenreRepository irgr)
        {
            _irgr = irgr;
        }

        [HttpGet]
        public IEnumerable<Reviewgenre> GetReviewgenres()
        {
            return _irgr.GetReviewgenres();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public void AddReviewgenre(Reviewgenre reviewgenre)
        {
            _irgr.AddReviewGenre(reviewgenre);
            _irgr.SaveChanges();
        }

        [HttpPut("{reviewgenre, user}")]
        public void BlokkeerUser(Reviewgenre reviewgenre, User user)
        {
            _irgr.BlokkeerUser(user, reviewgenre);
            _irgr.SaveChanges();
        }

        [HttpPut("{reviewgenre, user}")]
        public void DeblokkeerUser(Reviewgenre reviewgenre, User user)
        {
            _irgr.DeblokkeerUser(user, reviewgenre);
            _irgr.SaveChanges();
        }

        [HttpGet("{reviewgenre, user}")]
        public bool IsGeblokkeerd(Reviewgenre reviewgenre, User user)
        {
            return _irgr.IsGeblokkeerd(user, reviewgenre);
        }

        [HttpGet("{reviewgenre, user}")]
        public bool IsAdmin(Reviewgenre reviewgenre, User user)
        {
            return _irgr.IsAdmin(user, reviewgenre);
        }

        [HttpGet("{rebiewgenre}")]
        public string GetAdminNaam(Reviewgenre rg)
        {
            return _irgr.GetAdminNaam(rg);
        }
    }
}