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
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [ApiController]
    public class WerkController : ControllerBase
    {
        private readonly IWerkRepository _iwr;

        public WerkController(IWerkRepository iwr)
        {
            _iwr = iwr;
        }
        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<Werk> GetWerks()
        {
            return _iwr.GetWerks();
        }
        [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public void AddWerk(Werk werk)
        {
            _iwr.AddWerk(werk);
            _iwr.SaveChanges();
        }
    }
}