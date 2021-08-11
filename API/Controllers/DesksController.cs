using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DesksController : ControllerBase
    {
        private readonly IDeskRepository _repo;
        public DesksController(IDeskRepository repo)
        {
            this._repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Desk>>> GetDesks()
        {
            var desks = await _repo.GetDeskAsync();
            return Ok(desks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Desk>> GetDesk(int id)
        {
            return await _repo.GetDeskByIdAsync(id);
        }
        
        [HttpGet("rooms")]
        public async Task<ActionResult<IReadOnlyList<Room>>> GetRooms()
        {
            return Ok(await _repo.GetRoomsAsync());
        }
    }
}