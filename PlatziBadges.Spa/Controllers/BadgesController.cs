using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatziBadges.Entity;
using PlatziBadges.Service;

namespace PlatziBadges.Spa.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BadgesController : ControllerBase
    {
        private readonly IBadgeService _badgeService;
        public BadgesController(IBadgeService badgeService)
        {
            _badgeService = badgeService;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post([FromBody] Badge badge)
        {
            var result = await Post(_badgeService.Add(badge));
            return Ok(result);
        }
    }
}