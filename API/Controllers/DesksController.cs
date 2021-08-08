using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DesksController : ControllerBase
    {
        private readonly StoreContext _context;
        private readonly ILogger<WeatherForecastController> _logger;

        public DesksController(StoreContext context, ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Desk>>> GetDesks()
        {
            var desks = await _context.Desks.ToListAsync();
            return Ok(desks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Desk>> GetDesk(int id)
        {
            return await _context.Desks.FindAsync(id);
        }

    }
}