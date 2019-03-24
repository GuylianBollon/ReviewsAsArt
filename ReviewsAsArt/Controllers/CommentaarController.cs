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
    internal class CommentaarController : ControllerBase
    {
        private readonly ICommentaarRepository _icc;

        public CommentaarController(ICommentaarRepository icc)
        {
            _icc = icc;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("{commentaar}")]
        public void VoegCijferToe(Commentaar commentaar)
        {
            _icc.VoegScoreToe(commentaar);
            _icc.SaveChanges();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("{commentaar}")]
        public void VerwijderCijfer(Commentaar commentaar)
        {
            _icc.NeemScoreAf(commentaar);
            _icc.SaveChanges();
        }
    }
}