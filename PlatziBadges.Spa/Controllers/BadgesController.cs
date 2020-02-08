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
        [EnableCors]
        public async Task<IActionResult> Post([FromBody] Badge badge)
        {
            var result = await _badgeService.Add(badge);
            return Ok(result);
        }

        [HttpGet]
        [EnableCors]
        public async Task<IActionResult> Get()
        {
            var result =  await _badgeService.GetAll();
            return Ok(result);
        }
    }
}