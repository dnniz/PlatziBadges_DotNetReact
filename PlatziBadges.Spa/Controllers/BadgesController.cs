using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatziBadges.Entity;
using PlatziBadges.Service;
using Microsoft.AspNetCore.Cors;

namespace PlatziBadges.Spa.Controllers
{
    [Produces("application/json")]
    //Configuración de Politica [personalizada]
    [EnableCors("CORSReactPolicy")] //Borrar para [permitir todo]
    [Route("api/[controller]")]
    [ApiController]
    public class BadgesController : ControllerBase
    {
        private readonly IBadgeService _badgeService;

        public BadgesController(IBadgeService badgeService) => _badgeService = badgeService;


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Badge badge)
        {
            var result = await _badgeService.AddAsync(badge);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result =  await _badgeService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{badgeId}")]
        public async Task<IActionResult> Get(int badgeId)
        {
            var result = await _badgeService.GetByIdAsync(badgeId);
            return Ok(result);
        }

        [HttpPut("{badgeId}")]
        public async Task<IActionResult> Put(int badgeId, [FromBody] Badge update)
        {
            update.BadgeId = badgeId;
            var result = await _badgeService.UpdateAsync(update);
            return Ok(result);
        }

        [HttpDelete("{badgeId}")]
        public async Task<IActionResult> Delete(int badgeId)
        {
            var result = await _badgeService.DeleteAsync(badgeId);
            return Ok(result);
        }
    }
}