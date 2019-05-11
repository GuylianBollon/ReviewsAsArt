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
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [ApiController]
    public class ReviewGenreController : ControllerBase
    {
        private readonly IReviewGenreRepository _irgr;

        public ReviewGenreController(IReviewGenreRepository irgr)
        {
            _irgr = irgr;
        }
        [AllowAnonymous]
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

        [HttpPut("{admin}")]
        public void BlokkeerUser(AdminDTO admin)
        {
            _irgr.BlokkeerUser(admin.user, admin.rg);
            _irgr.SaveChanges();
        }

        [HttpPut("{admin}")]
        public void DeblokkeerUser(AdminDTO admin)
        {
            _irgr.DeblokkeerUser(admin.user, admin.rg);
            _irgr.SaveChanges();
        }

        [HttpGet("{admin}")]
        public bool IsGeblokkeerd(AdminDTO admin)
        {
            return _irgr.IsGeblokkeerd(admin.user, admin.rg);
        }

        [HttpGet("{admin}")]
        public bool IsAdmin(AdminDTO admin)
        {
            return _irgr.IsAdmin(admin.user, admin.rg);
        }

        [HttpGet("{reviewgenre}")]
        public string GetAdminNaam(Reviewgenre rg)
        {
            return _irgr.GetAdminNaam(rg);
        }
        
    }
}