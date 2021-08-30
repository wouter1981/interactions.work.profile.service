using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;

namespace profile.service.Controllers
{
    [ApiController]
    [Route("/")]
    public class ProfileController : ControllerBase
    {
        private readonly ILogger<ProfileController> _logger;

        public ProfileController(ILogger<ProfileController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Profile> ListAll()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index =>
            {
                var id = Guid.NewGuid();
                var path = base.Url.ActionLink(nameof(GetProfile), null, new { id = id });
                return new Profile { Id = id, Name = index.ToString(), Href = path };
            }).ToArray();
        }

        [HttpGet("{id:Guid}")]
        public Profile GetProfile(Guid id)
        {
            var path = base.Url.ActionLink(nameof(GetProfile), null, new { id = id });
            return new Profile { Id = id, Name = "Happy go lucky", Href = path };
        }
    }
}
